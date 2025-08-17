using PlayerRoles;

namespace WaveMusic
{
    public class Config
    {
        public string CiMusic { get; set; } = "path/to/ci-music";
        public string[] WhoCanHearCiMusic { get; set; } =
        {
            nameof(RoleTypeId.ChaosConscript),
            nameof(RoleTypeId.ChaosMarauder),
            nameof(RoleTypeId.ChaosRepressor),
            nameof(RoleTypeId.ChaosRifleman)
        };
        public bool DiableCiAnnouncement { get; set; } = false;
        public string MtfMusic { get; set; } = "path/to/mtf-music";
        public string[] WhoCanHearMtfMusic { get; set; } =
        {
            nameof(RoleTypeId.NtfCaptain),
            nameof(RoleTypeId.NtfPrivate),
            nameof(RoleTypeId.NtfSergeant),
            nameof(RoleTypeId.NtfSpecialist)
        };
        public bool DiableMtfAnnouncement { get; set; } = false;
    }
}