package Services;
import Models.Hiba;
import Models.Javitas;
import Enum.Szerelo;
import org.springframework.stereotype.Service;

@Service
public class Kalkulator implements IKalkulator {

    @Override
    public int JavitasKalkulator(Hiba hiba, Szerelo szerelo)
    {
        return hiba.getHibaktsg()+szerelo.getMunkaber()+ (int)(hiba.getHibaktsg()*0.35);

    }

    @Override
    public int Nyeresegkalkulator(Hiba hiba, Javitas javitas)
    {
        return  javitas.getJavitasktsg()-hiba.getHibaktsg()-javitas.getSzerelo().getMunkaber();
    }





}
