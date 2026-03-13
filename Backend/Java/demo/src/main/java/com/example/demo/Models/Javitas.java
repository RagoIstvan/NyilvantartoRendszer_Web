package com.example.demo.Models;
import com.example.demo.Enum.Szerelo;
import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;
import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;

@Data
@Entity
@NoArgsConstructor
@AllArgsConstructor
public class Javitas
{
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @JsonProperty("javaid")
    private int Id;

    @Enumerated(EnumType.STRING)
    @JsonProperty("szerelo")
    private Szerelo Szerelo;

    @JsonProperty("datum")
    private LocalDate Javitasdatum;

    @JsonProperty("javitasktsg")
    private int Javitasktsg;

    @JsonProperty("nyereseg")
    private int Nyereseg;

    @JsonProperty("munkaber")
    private int Munkaber;

    @OneToOne
    @JoinColumn(name = "hiba_id")
    @JsonIgnore
    private Hiba Hiba;

    @JsonProperty("hibaid")
    public Integer getCsharpHibaId() {
        if (this.Hiba != null) {

            return this.Hiba.getHibaId();
        }
        return null;
    }








}
