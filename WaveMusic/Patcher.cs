using HarmonyLib;
using Respawning.Announcements;
using Respawning.Waves;

// ReSharper disable InconsistentNaming

namespace WaveMusic
{
    [HarmonyPatch(typeof(WaveAnnouncementBase), nameof(WaveAnnouncementBase.PlayAnnouncement))]
    internal class PatchWaveAnnouncementBase
    {
        static bool Prefix(WaveAnnouncementBase __instance)
        {
            switch (__instance)
            {
                case NtfWaveAnnouncement or NtfMiniwaveAnnouncement when WaveMusic.Instance.PluginConfig.DiableMtfAnnouncement:
                case ChaosWaveAnnouncement or ChaosMiniwaveAnnouncement when WaveMusic.Instance.PluginConfig.DiableCiAnnouncement:
                    return false;
                default:
                    return true;
            }
        }
    }
}