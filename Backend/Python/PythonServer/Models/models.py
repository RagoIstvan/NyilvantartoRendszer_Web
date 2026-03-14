from sqlmodel import SQLModel, Field
from typing import Optional


class Hiba(SQLModel, table=True):
    id: Optional[int] = Field(default=None, primary_key=True)
    gyarto: str
    hibakod: str
    hibaktsg: int
    hibadatum: str
    javaId: Optional[int] = Field(default=None)

class Javitas(SQLModel, table=True):
    id: Optional[int] = Field(default=None, primary_key=True)
    hiba_id: int = Field(foreign_key="hiba.id")
    szerelo: str
    javitasdatum: str
    javitasktsg: int
    munkaber: int
    nyereseg: int

class Naplo(SQLModel, table=True):
    id: Optional[int] = Field(default=None, primary_key=True)
    hiba_id: int = Field(foreign_key="hiba.id")
    javitas_id: int = Field(foreign_key="javitas.id")
    szerelo: str
    hibakod: str
    javitasktsg: int
    datum: str

