package Services;

import Models.Hiba;
import Enum.Szerelo;
import Models.Javitas;

public interface IKalkulator {

    int JavitasKalkulator(Hiba hiba, Szerelo szerelo);

    int Nyeresegkalkulator(Hiba hiba, Javitas javitas);


}
