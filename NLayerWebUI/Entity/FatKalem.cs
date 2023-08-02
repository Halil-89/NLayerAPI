namespace NLayerWebUI.Entity
{
    public class FatKalem
    {

        public int FaturaKalemId { get; set; }
        public string StokKodu { get; set; }
        public double STra_GCMIK { get; set; }
        public double STra_NF { get; set; }
        public double STra_BF { get; set; }
        public string ProjeKodu { get; set; }
        public int DEPO_KODU { get; set; }
        public int FaturaId { get; set; }
        public FaturaUst Fatura { get; set; }
    }
}
