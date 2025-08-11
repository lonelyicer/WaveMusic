using LabApi.Events.Arguments.ServerEvents;
using LabApi.Events.CustomHandlers;
using PlayerRoles;
using Respawning.Announcements;
using Respawning.Waves;

namespace WaveMusic
{
    public class EventHandler: CustomEventsHandler
    {
        public override void OnServerRoundStarted()
        {
            AudioPlayer.CreateOrGet("mtf-music",
                condition: hub => hub.roleManager.CurrentRole.RoleTypeId is RoleTypeId.NtfCaptain
                    or RoleTypeId.NtfPrivate or RoleTypeId.NtfSergeant or RoleTypeId.NtfSpecialist,
                onIntialCreation: p =>
                {
                    p.AddSpeaker("Main", isSpatial: false, maxDistance: 5000f);
                });
            
            AudioPlayer.CreateOrGet("ci-music",
                condition: hub => hub.roleManager.CurrentRole.RoleTypeId is RoleTypeId.ChaosConscript
                    or RoleTypeId.ChaosRepressor or RoleTypeId.ChaosMarauder or RoleTypeId.ChaosRifleman,
                onIntialCreation: p =>
                {
                    p.AddSpeaker("Main", isSpatial: false, maxDistance: 5000f);
                });
        }

        public override void OnServerWaveRespawned(WaveRespawnedEventArgs ev)
        {
            if (ev.Wave.Base is NtfSpawnWave or NtfMiniWave)
            {
                AudioPlayer.TryGet("mtf-music", out var musicPlayer);
                musicPlayer.AddClip("mtf-music");
            }
            
            if (ev.Wave.Base is ChaosSpawnWave or ChaosMiniWave)
            {
                AudioPlayer.TryGet("ci-music", out var musicPlayer);
                musicPlayer.AddClip("ci-music");
            }
        }
    }
}