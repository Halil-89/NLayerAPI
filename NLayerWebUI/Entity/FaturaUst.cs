namespace NLayerWebUI.Entity
{
    public class FaturaUst
    {

        public int FaturaId { get; set; }
        public string CariKod { get; set; }
        public string FATIRS_NO { get; set; }
        public string Tarih { get; set; }
        public int Tip { get; set; }

        public int TIPI { get; set; }

        public bool KDV_DAHILMI { get; set; }
        public string SIPARIS_TEST { get; set; }

        public string PLA_KODU { get; set; }
        public string Proje_Kodu { get; set; }
        public ICollection<FatKalem> FaturaKalems { get; set; }
    }
}
