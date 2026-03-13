package Controller;

import Models.Hiba;
import Models.Javitas;
import Services.HibaJavitas;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/java")
@RequiredArgsConstructor
public class ApiController
{

    private final HibaJavitas _HibaJavitas;


    @PostMapping("/hiba")
    public List<Javitas> HibaJavitasKuldesFogadas(@RequestBody List<Hiba>CshapHibak)
    {

        _HibaJavitas.CsharpHibaJavitasa(CshapHibak);


        return  _HibaJavitas.JavitasokKiolvas();

    }





}
