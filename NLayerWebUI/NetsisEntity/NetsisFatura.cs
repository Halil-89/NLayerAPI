namespace NLayerWebUI.NetsisEntity
{
    public class NetsisFatura
    {
        public string Seri { get; set; }
        public bool KayitliNumaraOtomatikGuncellensin { get; set; }
        public NetsisFaturaUst FatUst { get; set; }
        public bool EPostaGonderilsin { get; set; }
        public List<NetsisFaturaKalem> Kalems { get; set; }
    }
}
