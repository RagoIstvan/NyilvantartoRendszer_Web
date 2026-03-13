package Enum;

public enum Szerelo {

    Nagy_Lajos(15500),
    Kiss_Beata(25000),
    Toth_Krisztian(18500),
    Varga_Geza(22000),
    Nemeth_Szilard(15500),
    Kovacs_Lajos(25000);

  private  final  int munkaber;

    public int getMunkaber() {
        return munkaber;
    }

    Szerelo(int munkaber) {
        this.munkaber = munkaber;
    }
}
