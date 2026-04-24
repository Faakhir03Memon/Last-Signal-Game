import React, { useState, useEffect } from 'react';
import { Car, DollarSign, Shield, Zap, Map as MapIcon, Music, Users } from 'lucide-react';
import { motion, AnimatePresence } from 'framer-motion';

const App = () => {
  const [stats, setStats] = useState({
    money: 15420,
    respect: 450,
    health: 100,
    wantedLevel: 2,
    location: 'Ocean Beach',
    activeVehicle: 'Infernus'
  });

  return (
    <div className="min-h-screen bg-[#1a0b2e] text-pink-100 font-['Inter'] overflow-hidden selection:bg-pink-500/30">
      {/* 80s Grid Background */}
      <div className="fixed inset-0 z-0 bg-[linear-gradient(to_bottom,#1a0b2e_0%,#3d1a5a_100%)]">
        <div className="absolute inset-0 bg-[linear-gradient(90deg,rgba(255,0,150,0.1)_1px,transparent_1px),linear-gradient(rgba(255,0,150,0.1)_1px,transparent_1px)] bg-[size:40px_40px] [transform:perspective(500px)_rotateX(60deg)_translateY(-100px)] animate-[grid_20s_linear_infinite]" />
      </div>

      {/* Main HUD */}
      <div className="relative z-10 flex flex-col h-screen">
        {/* Header - Neon Title */}
        <header className="p-6 flex justify-between items-start">
          <motion.div 
            initial={{ opacity: 0, y: -20 }}
            animate={{ opacity: 1, y: 0 }}
            className="flex flex-col"
          >
            <h1 className="text-5xl font-['Orbitron'] font-black italic tracking-tighter text-transparent bg-clip-text bg-gradient-to-b from-pink-400 to-purple-600 drop-shadow-[0_0_10px_rgba(255,0,150,0.5)]">
              VICE <span className="text-cyan-400">CLONE</span>
            </h1>
            <span className="text-xs tracking-[0.5em] text-cyan-300 font-bold ml-1 uppercase">Criminal Enterprise</span>
          </motion.div>

          <div className="flex gap-4">
            <HudCard icon={<DollarSign className="text-green-400" />} value={`$${stats.money.toLocaleString()}`} label="CASH" />
            <HudCard icon={<Shield className="text-blue-400" />} value={`${stats.health}%`} label="HEALTH" />
          </div>
        </header>

        {/* Center Console */}
        <main className="flex-1 p-6 grid grid-cols-12 gap-6 items-end">
          {/* Left Side - Navigation */}
          <div className="col-span-3 space-y-4">
            <NavTab icon={<MapIcon />} label="CITY MAP" />
            <NavTab icon={<Music />} label="RADIO: FLASH FM" active />
            <NavTab icon={<Users />} label="ASSETS" />
          </div>

          {/* Center - Wanted Level */}
          <div className="col-span-6 flex flex-col items-center pb-12">
            <div className="flex gap-2">
              {[...Array(5)].map((_, i) => (
                <motion.div
                  key={i}
                  animate={{ 
                    scale: i < stats.wantedLevel ? [1, 1.2, 1] : 1,
                    opacity: i < stats.wantedLevel ? 1 : 0.2
                  }}
                  transition={{ repeat: Infinity, duration: 1 }}
                >
                  <Shield size={32} className={i < stats.wantedLevel ? "text-yellow-400 fill-yellow-400 drop-shadow-[0_0_8px_rgba(255,255,0,0.8)]" : "text-gray-600"} />
                </motion.div>
              ))}
            </div>
            <span className="text-xs font-bold tracking-[1em] text-yellow-500 mt-2">WANTED</span>
          </div>

          {/* Right Side - Vehicle Info */}
          <div className="col-span-3">
            <div className="bg-black/60 border-l-4 border-pink-500 p-6 backdrop-blur-xl rounded-r-xl">
              <div className="flex items-center gap-3 mb-4">
                <Car className="text-pink-400" size={24} />
                <h2 className="font-['Orbitron'] text-sm tracking-widest text-pink-300 uppercase">Current Vehicle</h2>
              </div>
              <h3 className="text-3xl font-black italic text-white mb-2">{stats.activeVehicle}</h3>
              <div className="space-y-2">
                <ProgressBar label="Engine" value={85} color="bg-pink-500" />
                <ProgressBar label="Body" value={92} color="bg-cyan-500" />
              </div>
            </div>
          </div>
        </main>

        {/* Footer - Location Bar */}
        <footer className="p-4 bg-gradient-to-r from-pink-500/20 via-purple-500/20 to-cyan-500/20 backdrop-blur-sm border-t border-white/10">
          <div className="max-w-7xl mx-auto flex justify-between items-center px-6">
            <div className="flex items-center gap-4">
              <Zap className="text-yellow-400 animate-pulse" size={16} />
              <span className="text-xs font-mono tracking-widest uppercase text-white/80">Location: {stats.location}</span>
            </div>
            <div className="text-[10px] text-pink-400 font-bold tracking-widest">STABILITY: OPTIMAL // 60 FPS</div>
          </div>
        </footer>
      </div>

      <style dangerouslySetInnerHTML={{ __html: `
        @keyframes grid {
          0% { background-position: 0 0; }
          100% { background-position: 0 40px; }
        }
      `}} />
    </div>
  );
};

const HudCard = ({ icon, value, label }) => (
  <div className="bg-black/40 border-b-2 border-cyan-500/50 p-4 min-w-[150px] backdrop-blur-md">
    <div className="flex items-center gap-2 mb-1">
      {icon}
      <span className="text-[10px] font-bold tracking-widest text-cyan-400">{label}</span>
    </div>
    <div className="text-2xl font-['Orbitron'] font-bold text-white italic">{value}</div>
  </div>
);

const NavTab = ({ icon, label, active = false }) => (
  <button className={`w-full flex items-center gap-4 px-6 py-4 transition-all border-l-2 ${
    active 
      ? 'bg-pink-500/20 border-pink-500 text-pink-300' 
      : 'bg-black/20 border-transparent text-gray-500 hover:bg-white/5 hover:text-white'
  }`}>
    {icon}
    <span className="font-['Orbitron'] text-xs font-bold tracking-widest">{label}</span>
  </button>
);

const ProgressBar = ({ label, value, color }) => (
  <div className="space-y-1">
    <div className="flex justify-between text-[10px] font-bold text-gray-400 uppercase tracking-tighter">
      <span>{label}</span>
      <span>{value}%</span>
    </div>
    <div className="h-1 bg-white/5 rounded-full overflow-hidden">
      <motion.div 
        initial={{ width: 0 }}
        animate={{ width: `${value}%` }}
        className={`h-full ${color}`} 
      />
    </div>
  </div>
);

export default App;
