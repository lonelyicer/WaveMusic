using System;
using System.Reflection;
using HarmonyLib;
using LabApi.Events.CustomHandlers;
using LabApi.Features;
using LabApi.Features.Console;
using LabApi.Loader.Features.Plugins;

namespace WaveMusic
{
    public class WaveMusic: Plugin<Config>
    {
        public override string Name => "WaveMusic";
        public override string Description => "A simple plugin that will play music at wave spawned";
        public override string Author => "RingLo_";
        public override Version Version => Assembly.GetExecutingAssembly().GetName().Version;
        public override Version RequiredApiVersion => new(LabApiProperties.CompiledVersion);
        
        public override string ConfigFileName { get; set; } = "wavemusic-config.yml";
        
        private readonly EventHandler _eventHandler = new();
        private Harmony _harmony;

        public static WaveMusic Instance;
        public Config PluginConfig;

        public override void Enable()
        {
            Logger.Info("WaveMusic is loading...");
            PluginConfig = Config;
            Instance = this;
            
            Logger.Info("Loading music...");
            LoadMusic();
            
            Logger.Info("Registering events...");
            CustomHandlersManager.RegisterEventsHandler(_eventHandler);
            
            Logger.Info("Patching...");
            _harmony = new Harmony($"{Name.ToLower()}.{DateTime.UtcNow.Ticks}");
            _harmony.PatchAll();
        }

        public override void Disable()
        {
            Logger.Info("WaveMusic is unloading...");
            PluginConfig = null;
            Instance = null;
            
            Logger.Info("Unloading music...");
            DestroyMusic();
            
            Logger.Info("Unregistering events...");
            CustomHandlersManager.UnregisterEventsHandler(_eventHandler);
            
            Logger.Info("Unpatching...");
            _harmony.UnpatchAll();
            _harmony = null;
        }

        private void LoadMusic()
        {
            AudioClipStorage.LoadClip(PluginConfig.CiMusic, "ci-music");
            AudioClipStorage.LoadClip(PluginConfig.MtfMusic, "mtf-music");
        }

        private static void DestroyMusic()
        {
            AudioClipStorage.DestroyClip("mtf-music");
            AudioClipStorage.DestroyClip("ci-music");
        }
    }
}