from fastapi import FastAPI, HTTPException
from pydantic import BaseModel
from typing import List, Optional
import uvicorn

app = FastAPI(title="Last Signal API")

# Models
class SignalData(BaseModel):
    signal_id: str
    name: str
    is_decoded: bool
    data_content: Optional[str] = None

class PlayerProgress(BaseModel):
    player_id: str
    discovered_signals: List[str]
    battery_level: float
    scrap_count: int
    hunger: float = 100.0
    energy: float = 100.0
    thirst: float = 100.0

# In-memory storage (Replace with DB later)
signals_db = {}
player_db = {
    "hunter_1": PlayerProgress(
        player_id="hunter_1",
        discovered_signals=[],
        battery_level=100.0,
        scrap_count=0
    )
}

@app.get("/")
async def root():
    return {"message": "Last Signal Backend Active"}

@app.get("/signals", response_model=List[SignalData])
async def get_signals():
    return list(signals_db.values())

@app.post("/signals/discover")
async def discover_signal(signal: SignalData):
    signals_db[signal.signal_id] = signal
    if signal.signal_id not in player_db["hunter_1"].discovered_signals:
        player_db["hunter_1"].discovered_signals.append(signal.signal_id)
    return {"status": "success", "message": f"Signal {signal.name} recorded"}

@app.get("/player/progress", response_model=PlayerProgress)
async def get_progress():
    return player_db["hunter_1"]

@app.post("/player/update")
async def update_progress(progress: PlayerProgress):
    player_db[progress.player_id] = progress
    return {"status": "success"}

if __name__ == "__main__":
    uvicorn.run(app, host="0.0.0.0", port=8000)
