package com.example.demo.Services;

import com.example.demo.Models.Hiba;
import com.example.demo.Enum.Szerelo;
import com.example.demo.Models.Javitas;

public interface IKalkulator {

    int JavitasKalkulator(Hiba hiba, Szerelo szerelo);

    int Nyeresegkalkulator(Hiba hiba, Javitas javitas);


}
