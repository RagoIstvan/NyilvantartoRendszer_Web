package com.example.demo.Services;

import com.example.demo.Data.Hibadb;
import com.example.demo.Data.Javitasrepostory;
import com.example.demo.Models.Hiba;
import com.example.demo.Models.Javitas;
import com.example.demo.Enum.Szerelo;
import jakarta.transaction.Transactional;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Random;

@Service
public class HibaJavitas {


    private final Kalkulator kalkulator;
    private final Hibadb _Hibadb;
    private final Javitasrepostory _JavitasRepostory;

    public HibaJavitas(Kalkulator kalkulator, Hibadb hibadb, Javitasrepostory javitasRepostory) {
        this.kalkulator = kalkulator;
        _Hibadb = hibadb;
        _JavitasRepostory = javitasRepostory;
    }

    Random rnd = new Random();

    public Szerelo SzereloGeneral() {
        Szerelo[] szerelok = Szerelo.values();

        return szerelok[rnd.nextInt(szerelok.length)];
    }

    private void EgyHibaJavitasa(Hiba hiba) {

        Javitas ujjavitas = new Javitas();

        Szerelo randomszerelo=SzereloGeneral();
        ujjavitas.setSzerelo(randomszerelo);
        ujjavitas.setMunkaber(randomszerelo.getMunkaber());
        ujjavitas.setHiba(hiba);
        ujjavitas.setJavitasdatum(hiba.getHibaDatuma().plusDays(rnd.nextInt(1, 15)));
        ujjavitas.setJavitasktsg(kalkulator.JavitasKalkulator(hiba, ujjavitas.getSzerelo()));
        ujjavitas.setNyereseg(kalkulator.Nyeresegkalkulator(hiba, ujjavitas));

        _JavitasRepostory.save(ujjavitas);
    }


    @Transactional
    public void CsharpHibaJavitasa(List<Hiba> Bejovohiba) {

        if (Bejovohiba != null) {
            var mentetthibak = _Hibadb.saveAll(Bejovohiba);

            for (var sor : mentetthibak) {

                EgyHibaJavitasa(sor);

            }




        }
        else
        {
            System.out.println("Valami nem volt jó a bejövöhiba beérkezésében!");
        }


    }


    public List<Javitas> JavitasokKiolvas()
    {
       return _JavitasRepostory.findAll().stream().toList();

    }



}