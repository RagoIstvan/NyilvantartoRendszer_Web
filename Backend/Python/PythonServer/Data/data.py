
from sqlmodel import SQLModel, create_engine, Session


sqlite_fajlnev = "mikroszerviz.db"
sqlite_url = f"sqlite:///{sqlite_fajlnev}"


engine = create_engine(sqlite_url, echo=False)

def tablak_letrehozasa():
    SQLModel.metadata.create_all(engine)
    print("✅ Adatbázis táblák ellenőrizve / létrehozva!")

def get_session():
    with Session(engine) as session:
        yield session