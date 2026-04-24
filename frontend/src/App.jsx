import React, { useState, useEffect } from 'react';
import { Radio, Battery, Cpu, Database, Map, Settings, Wifi } from 'lucide-react';
import { motion, AnimatePresence } from 'framer-motion';

const App = () => {
  const [signals, setSignals] = useState([]);
  const [progress, setProgress] = useState({
    battery_level: 0,
    scrap_count: 0,
    discovered_signals: []
  });
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    // Simulated data fetching from Python Backend
    const fetchData = async () => {
      try {
        // In a real scenario, this would be:
        // const resSignals = await fetch('http://localhost:8000/signals');
        // const resProgress = await fetch('http://localhost:8000/player/progress');
        
        // Mock data for initial look
        setSignals([
          { signal_id: 'SIG_001', name: 'Abandoned Tower', is_decoded: true, timestamp: '2024-04-24 14:30' },
          { signal_id: 'SIG_002', name: 'Sublevel Bunker', is_decoded: false, timestamp: 'Pending...' },
        ]);
        setProgress({
          battery_level: 85,
          scrap_count: 124,
          discovered_signals: ['SIG_001']
        });
        setLoading(false);
      } catch (error) {
        console.error("Failed to fetch data from backend", error);
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  return (
    <div className="min-h-screen bg-[#050505] text-cyan-50 font-['Inter'] selection:bg-cyan-500/30">
      {/* HUD Header */}
      <header className="border-b border-cyan-900/30 bg-black/50 backdrop-blur-md sticky top-0 z-50">
        <div className="max-w-7xl mx-auto px-6 py-4 flex justify-between items-center">
          <div className="flex items-center gap-3">
            <Radio className="text-cyan-400 animate-pulse" size={28} />
            <h1 className="font-['Orbitron'] text-xl tracking-widest font-bold bg-gradient-to-r from-cyan-400 to-blue-500 bg-clip-text text-transparent">
              LAST SIGNAL <span className="text-[10px] text-cyan-700 align-top">V1.0</span>
            </h1>
          </div>
          
          <div className="flex items-center gap-8 text-sm">
            <div className="flex items-center gap-2">
              <Battery className={`${progress.battery_level < 20 ? 'text-red-500 animate-bounce' : 'text-green-400'}`} size={18} />
              <span className="font-mono">{progress.battery_level}%</span>
            </div>
            <div className="flex items-center gap-2">
              <Cpu className="text-amber-400" size={18} />
              <span className="font-mono">{progress.scrap_count} UNITS</span>
            </div>
          </div>
        </div>
      </header>

      <main className="max-w-7xl mx-auto p-6 grid grid-cols-1 lg:grid-cols-12 gap-6">
        {/* Sidebar Navigation */}
        <nav className="lg:col-span-2 flex lg:flex-col gap-2">
          <NavButton icon={<Database size={20} />} label="SIGNALS" active />
          <NavButton icon={<Map size={20} />} label="MAP" />
          <NavButton icon={<Settings size={20} />} label="SYSTEM" />
        </nav>

        {/* Main Content Area */}
        <section className="lg:col-span-10">
          <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
            {/* Active Signals List */}
            <div className="bg-cyan-950/10 border border-cyan-900/20 rounded-xl p-6 backdrop-blur-sm">
              <div className="flex items-center justify-between mb-6">
                <h2 className="font-['Orbitron'] text-sm tracking-widest text-cyan-400">DETECTED SIGNALS</h2>
                <Wifi size={16} className="text-cyan-700" />
              </div>
              
              <div className="space-y-4">
                {signals.map(signal => (
                  <motion.div 
                    initial={{ opacity: 0, x: -20 }}
                    animate={{ opacity: 1, x: 0 }}
                    key={signal.signal_id}
                    className={`p-4 border rounded-lg transition-all ${
                      signal.is_decoded 
                        ? 'bg-cyan-500/5 border-cyan-500/20 shadow-[0_0_15px_rgba(6,182,212,0.05)]' 
                        : 'bg-black/40 border-white/5 opacity-60'
                    }`}
                  >
                    <div className="flex justify-between items-start mb-2">
                      <span className="text-xs font-mono text-cyan-700">{signal.signal_id}</span>
                      {signal.is_decoded && <span className="text-[10px] bg-cyan-500/20 text-cyan-400 px-2 py-0.5 rounded uppercase tracking-tighter">Decoded</span>}
                    </div>
                    <h3 className="font-semibold text-lg">{signal.name}</h3>
                    <p className="text-xs text-cyan-700 mt-2">{signal.timestamp}</p>
                  </motion.div>
                ))}
              </div>
            </div>

            {/* Neural Reconstruction Card */}
            <div className="bg-blue-950/10 border border-blue-900/20 rounded-xl p-6 flex flex-col items-center justify-center text-center group overflow-hidden relative">
              <div className="absolute inset-0 bg-gradient-to-b from-blue-500/5 to-transparent pointer-events-none" />
              <div className="w-32 h-32 rounded-full border-2 border-dashed border-blue-500/30 flex items-center justify-center mb-6 group-hover:scale-110 transition-transform duration-700">
                <div className="w-24 h-24 rounded-full border border-blue-400/50 flex items-center justify-center animate-[spin_10s_linear_infinite]">
                  <div className="w-2 h-2 bg-blue-400 rounded-full" />
                </div>
              </div>
              <h2 className="font-['Orbitron'] text-lg mb-2">NEURAL RECONSTRUCTION</h2>
              <p className="text-sm text-blue-300/60 max-w-[250px]">
                Reconstructing fragmented data into coherent visual memories...
              </p>
              <div className="mt-6 w-full bg-blue-900/20 h-1 rounded-full overflow-hidden">
                <motion.div 
                  initial={{ width: 0 }}
                  animate={{ width: '42%' }}
                  className="h-full bg-blue-500" 
                />
              </div>
              <span className="text-[10px] mt-2 font-mono text-blue-500/50">STABILITY: 42.8%</span>
            </div>
          </div>
        </section>
      </main>

      {/* Background Ambience */}
      <div className="fixed inset-0 -z-10 bg-[radial-gradient(circle_at_50%_50%,rgba(6,78,113,0.1),transparent)] pointer-events-none" />
      <div className="fixed inset-0 -z-20 [background-image:linear-gradient(rgba(18,16,16,0)_50%,rgba(0,0,0,0.25)_50%),linear-gradient(90deg,rgba(255,0,0,0.06),rgba(0,255,0,0.02),rgba(0,0,255,0.06))] [background-size:100%_2px,3px_100%] pointer-events-none" />
    </div>
  );
};

const NavButton = ({ icon, label, active = false }) => (
  <button className={`flex items-center gap-3 px-4 py-3 rounded-lg text-sm font-medium transition-all ${
    active 
      ? 'bg-cyan-500/10 text-cyan-400 border border-cyan-500/20' 
      : 'text-gray-500 hover:text-cyan-300 hover:bg-white/5'
  }`}>
    {icon}
    <span className="tracking-widest font-['Orbitron']">{label}</span>
  </button>
);

export default App;
