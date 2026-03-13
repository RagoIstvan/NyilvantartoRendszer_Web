package com.example.demo.Controller;

import com.example.demo.Data.Hibadb;
import com.example.demo.Data.Javitasrepostory;
import com.example.demo.Models.Hiba;
import com.example.demo.Models.Javitas;
import com.example.demo.Services.HibaJavitas;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/java")
@RequiredArgsConstructor
public class ApiController
{

    private final HibaJavitas _HibaJavitas;
    private  final Hibadb _Hibadb;
    private  final Javitasrepostory _JavitasRepostory;

    @PostMapping("/hiba")
    public List<Javitas> HibaJavitasKuldesFogadas(@RequestBody List<Hiba>CshapHibak)
    {
        System.out.println(">>> FIGYELEM! Kérés érkezett a C#-ból! Kapott hibák száma: " + CshapHibak.size());

        _HibaJavitas.CsharpHibaJavitasa(CshapHibak);


        System.out.println("Hibák kiiratása");

        for (var sor : _Hibadb.findAll().stream().toList())
        {
            System.out.println(sor);
        }

        System.out.println("Javítások kiiratása");

        for (var sor : _JavitasRepostory.findAll().stream().toList())
        {
            System.out.println(sor);
        }
        return  _HibaJavitas.JavitasokKiolvas();

    }





}
