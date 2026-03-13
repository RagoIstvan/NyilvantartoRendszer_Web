package Models;
import com.fasterxml.jackson.annotation.JsonProperty;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;

@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Hiba
{

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private   int Id;

    @JsonProperty("hibakod")
    private String Hibakod;

    @JsonProperty("hibaktsg")
    private int Hibaktsg;

    @JsonProperty("hibadatum")
    private LocalDate HibaDatuma;

    @JsonProperty("Id")
    private int HibaId;



}
