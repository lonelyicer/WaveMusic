using LabApi.Events.Arguments.ServerEvents;
using LabApi.Events.CustomHandlers;
using PlayerRoles;
using Respawning.Announcements;
using Respawning.Waves;

namespace WaveMusic
{
    public class EventHandler: CustomEventsHandler
    {
        public override void OnServerWaveRespawned(WaveRespawnedEventArgs ev)
        {
            switch (ev.Wave.Base)
            {
                case NtfSpawnWave or NtfMiniWave:
                {
                    var musicPlayer = AudioPlayer.CreateOrGet("mtf-music",
                        condition: hub => hub.roleManager.CurrentRole.RoleTypeId is RoleTypeId.NtfCaptain
                            or RoleTypeId.NtfPrivate or RoleTypeId.NtfSergeant or RoleTypeId.NtfSpecialist,
                        onIntialCreation: p =>
                        {
                            p.AddSpeaker("Main", isSpatial: false, maxDistance: 5000f);
                        });
                    musicPlayer.AddClip("mtf-music");
                    break;
                }
                case ChaosSpawnWave or ChaosMiniWave:
                {
                    var musicPlayer = AudioPlayer.CreateOrGet("ci-music",
                        condition: hub => hub.roleManager.CurrentRole.RoleTypeId is RoleTypeId.NtfCaptain
                            or RoleTypeId.NtfPrivate or RoleTypeId.NtfSergeant or RoleTypeId.NtfSpecialist,
                        onIntialCreation: p =>
                        {
                            p.AddSpeaker("Main", isSpatial: false, maxDistance: 5000f);
                        });
                    musicPlayer.AddClip("ci-music");
                    break;
                }
            }
        }
    }
}