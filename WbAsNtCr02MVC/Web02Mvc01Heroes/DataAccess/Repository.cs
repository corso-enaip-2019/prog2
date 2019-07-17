using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Web02Mvc01Heroes.Models;
using Web02Mvc01Heroes.ViewModels;
using Web02Mvc01Heroes.ViewModels.VillainsViewModels;

namespace Web02Mvc01Heroes.DataAccess
{
    public class Repository
    {
        #region singleton
        static Repository()
        {
            Instance = new Repository();
        }

        public static Repository Instance { get; }
        #endregion

       
        private Repository()
        {
            #region Istanze gia_ pronte di nemici

            Villain jkr = new Villain { ID = 1, NameSecret = "NA", NameVillain = "The Joker", CanFly = false, Characteristics = "Mad, Poison-specialist", Debut = new DateTime(1940, 4, 25), KidnappedPeople = 1337, KilledPeople = 888, Strength = 6/*, Nemesis = bat*/ };
            Villain mgn = new Villain { ID = 2, NameSecret = "Max Eisenhardt AKA Erik Magnus Lehnsherr", NameVillain = "Magneto", CanFly = true, Characteristics = "Magnetist, Ego", Debut = new DateTime(1963, 9, 1), KidnappedPeople = 1000, KilledPeople = 2221, Strength = 3/*, Nemesis = xvr*/ };
            Villain frd = new Villain { ID = 3, NameSecret = "Fred Krueger", NameVillain = "Freddy Krueger", CanFly = false, Characteristics = "Immortal, Mask", Debut = new DateTime(1984, 1, 1), KidnappedPeople = 5, KilledPeople = 30, Strength = 10, Nemesis = null };
            Villain jsn = new Villain { ID = 4, NameSecret = "Jason Voorhees", NameVillain = "Jason", CanFly = false, Characteristics = "Immortal, Scalpels", Debut = new DateTime(1980, 1, 1), KidnappedPeople = 1, KilledPeople = 45, Strength = 10, Nemesis = null };

            #endregion

            #region Istanze gia_ pronte d_eroi
            SuperHero spr = new SuperHero { ID = 1, NameSecret = "Kal El", NameHero = "SuperMan", Strength = 100, AssetsValue = 100, CanFly = true, Powers = "Heat-ray, Bullet-proof, Ice-breath" };
            SuperHero bat = new SuperHero { ID = 2, NameSecret = "Bruce Wane", NameHero = "BatMan", Strength = 9, AssetsValue = 100_000_000_000, CanFly = false, Powers = "Ninja" };
            SuperHero ww = new SuperHero { ID = 3, NameSecret = "Diana Prince", NameHero = "WonderWoman", Strength = 70, AssetsValue = 100_000, CanFly = true, Powers = "Truth-lazo, Bullet-proof" };
            SuperHero plc = new SuperHero { ID = 4, NameSecret = "Police", NameHero = "Police", Strength = 5, AssetsValue = 100_000, CanFly = true, Powers = "Law, Bribes" };
            SuperHero xvr = new SuperHero { ID = 5, NameSecret = "Charles Xavier", NameHero = "Prof.X", Strength = 1, AssetsValue = 80_000_000, CanFly = true, Powers = "PSI, Patrick Stewart" };
            #endregion

            /* Popolamento delle nemesi (all'interno dell'oggetto-cattivo). */
            jkr.Nemesis = bat;
            mgn.Nemesis = xvr;

            /* Popolamento dei nemici (all'interno dell'oggetto-eroe). */
            spr.Enemies = new List<Villain> { };
            bat.Enemies = new List<Villain> { jkr };
            ww.Enemies = new List<Villain> { };
            plc.Enemies = new List<Villain> { jkr, mgn, frd, jsn };
            xvr.Enemies = new List<Villain> { mgn };

            /* Popolamento delle due liste pubbliche con eroi/nemici pre-generati. */
            List<Villain> _villains = new List<Villain> { jkr, mgn, frd, jsn };
            List<SuperHero> _superHeroes = new List<SuperHero> { spr, bat, ww, plc, xvr };
        }

        #region SuperHero_related for Villains
        /* /!\ Brutto, devo capire come farlo meglio. /!\ */
        internal List<SuperHeroesRadioListForVillainsEditViewModel> GetHeroList_ForVillainSEdit()
        {
            List<SuperHeroesRadioListForVillainsEditViewModel> outList = new List<SuperHeroesRadioListForVillainsEditViewModel>();
            foreach (SuperHero s in _superHeroes)
            {
                outList.Add(new SuperHeroesRadioListForVillainsEditViewModel(s.ID, s.NameHero));
            }

            return outList;
        }
        //=> _superHeroes.Where(s => s.ID > 0).Select(s => new SuperHeroesRadioListForVillainsEditViewModel(s.ID,s.NameHero))
        #endregion

        #region Villain_related for SuperHeroes
        #endregion

        #region superHeroes
        internal List<SuperHero> GetFullSuperHeroList3() => _superHeroes.Where(x => x.ID > 0).ToList<SuperHero>();
        /* /!\ Brutto, devo capire come farlo meglio. /!\ */
        internal List<SuperHero> GetFullSuperHeroList2()
        {
            List<SuperHero> ol = new List<SuperHero>();
            foreach (SuperHero s in _superHeroes)
            {
                ol.Add(s);
            }
            return ol;
        }

        internal int InsertSuperHero(SuperHero model)
        {
            throw new NotImplementedException();
        }

        internal SuperHero GetSuperHeroesFromID(int id)
        {
            return _superHeroes.FirstOrDefault(x => x.ID == id);
        }

        internal IEnumerable<SuperHero> GetAllSuperHeroes()
        {
            return _superHeroes;
        }

        public List<SuperHero> GetAllSuperHeroesViewModel()
        {
            return _superHeroes
                /* .??? */
                /* .??? */;
        }

        /* !!! DA FARE !!! */
        internal int UpdateSuperHero(int id, SuperHero model)
        {
            /* id=SHeroDaModificare, model=modificato.*/
            //Controllare l'id ed il model ID


            //int iDToUse = (_superHeroes.Count == 0) ? 1 : _superHeroes.Max(x => x.ID) + 1;

            //int maxID;
            //if (_superHeroes.Count == 0)
            //    maxID = 0;
            //else
            //    maxID = _superHeroes.Max(x => x.ID);

            //model.ID = maxID + 1;
            //_superHeroes.Add(model);
            return model.ID;
        }

        public bool RemoveSuperHeroByID(int id)
        {
            var toRemove = _superHeroes.FirstOrDefault(x => x.ID == id);

            // Usando il fatto che .Remove restituisce già un bool (senza controllo se c'è qualcosa da rimuovere o meno).
            return _superHeroes.Remove(toRemove);

            // Usando il fatto che .Remove restituisce già un bool + controllo se c'è qualcosa da rimuovere.
            //return (toRemove != null) ? _models.Remove(toRemove) : false;

            // Se esiste qualcosa da rimuovere, sempre «return true;» altrimenti sempre «return false;».
            //if (toRemove != null)
            //{
            //    _models.Remove(toRemove);
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            //int deletedRows=_models
            //.Where(x=>x.ID==id)
        }
        #endregion

        #region villains

        internal int InsertVillain(Villain model)
        {
            //int iDToUse = (_villains.Count == 0) ? 1 : _villains.Max(x => x.ID) + 1;

            int maxID;
            if (_villains.Count == 0)
                maxID = 0;
            else
                maxID = _villains.Max(x => x.ID);

            model.ID = maxID + 1;
            _villains.Add(model);

            return model.ID;
        }

        public /*internal*/ List<VillainsHomeListViewModel> GetVillainsFor_HomeList()
        {
            List<VillainsHomeListViewModel> outList = new List<VillainsHomeListViewModel>();

            foreach (Villain v in _villains)
            {
                outList.Add(new VillainsHomeListViewModel(v.ID, v.NameVillain, v.KidnappedPeople, v.Strength));
            }

            return outList;
        }

        /*
        internal int InsertVillain(VillainInsert_ViewModel model)
        {
            //int iDToUse = (_villains.Count == 0) ? 1 : _villains.Max(x => x.ID) + 1;

            int maxID;
            if (_villains.Count == 0)
                maxID = 0;
            else
                maxID = _villains.Max(x => x.ID);

            model.ID = maxID + 1;
            //_villains.Add(model);

            return model.ID;
        }
        */

        internal Villain GetVillainFromID(int id)
        {
            return _villains.FirstOrDefault(x => x.ID == id);
        }

        internal IEnumerable<Villain> GetAllVillains()
        {
            return _villains;
        }

        /* !!! DA FARE !!! */
        internal int UpdateVillain(int id, Villain model)
        {
            ///*  */

            ////int iDToUse = (_villains.Count == 0) ? 1 : _villains.Max(x => x.ID) + 1;

            //int maxID;
            //if (_villains.Count == 0)
            //    maxID = 0;
            //else
            //    maxID = _villains.Max(x => x.ID);

            //model.ID = maxID + 1;
            //_villains.Add(model);

            return model.ID;
        }




        public bool RemoveVillainByID(int id)
        {
            var toRemove = _villains.FirstOrDefault(x => x.ID == id);

            // Usando il fatto che .Remove restituisce già un bool (senza controllo se c'è qualcosa da rimuovere o meno).
            return _villains.Remove(toRemove);

            // Usando il fatto che .Remove restituisce già un bool + controllo se c'è qualcosa da rimuovere.
            //return (toRemove != null) ? _models.Remove(toRemove) : false;

            // Se esiste qualcosa da rimuovere, sempre «return true;» altrimenti sempre «return false;».
            //if (toRemove != null)
            //{
            //    _models.Remove(toRemove);
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            //int deletedRows=_models
            //.Where(x=>x.ID==id)
        }

        internal bool EditVillain(Villain editedVillain)
        {
            Villain villainToEdit = _villains.Where(x => x.ID == editedVillain.ID).FirstOrDefault();
            if (villainToEdit == null)
            {
                return false;
            }
            else
            {
                //_villains.Where(x => x.ID == editedVillain.ID).FirstOrDefault() = editedVillain;
                _villains.Remove(_villains.FirstOrDefault(x => x.ID == villainToEdit.ID));
                _villains.Add(editedVillain);
                _villains.OrderBy(x => x.ID);
                return true;
            }
        }

        internal bool DeleteVillainByID(int iDOfVillainToDelete)
        {
            if (_villains.Where(x => x.ID == iDOfVillainToDelete) == null)
            {
                return false;
            }
            else
            {
                _villains.Remove(_villains.FirstOrDefault(x => x.ID == iDOfVillainToDelete));
                return true;
            }
        }

        internal VillainsVillainToDeleteViewModel GetVillainForDeletePageFromID(int iDOfVillainToDelete)
        {
            Villain v = _villains
                .Where(x => x.ID == iDOfVillainToDelete)
                .FirstOrDefault();

            return (new VillainsVillainToDeleteViewModel { ID = v.ID, NameVillain = v.NameVillain });
        }

        internal string GetNameVillainFromID(int iDOfVillain)
        {
            Villain v = _villains
                .Where(x => x.ID == iDOfVillain)
                .FirstOrDefault();

            return (v == null ? "[Villain not found!]" : v.NameVillain.ToString());
        }

        internal VillainsVillainToEditViewModel GetVillainForEditPageFromID(int iDOfVillainToEdit)
        {
            Villain v = _villains
                .Where(x => x.ID == iDOfVillainToEdit)
                .FirstOrDefault();

            return new VillainsVillainToEditViewModel(v.ID, v.NameVillain, v.NameSecret, v.KidnappedPeople, v.KidnappedPeople, v.CanFly, v.Strength, v.Nemesis);
        }
        #endregion

        public List<Villain> _villains;
        public List<SuperHero> _superHeroes;



        #region old_logan
        //public SuperHero Get(int id) => _superHeroes.FirstOrDefault(x => x.ID == id);

        //public List<SuperHero> GetAll() => _superHeroes.ToList();

        //public int InsertSHero(SuperHero model)
        //{
        //    #region controlli
        //    if (model == null)
        //        throw new InvalidInputException("null input");

        //    return BadRequest("null model");

        //    if (model.ID != 0)
        //        return new StatusCodeResult(StatusCodes.Status422UnprocessableEntity);
        //    #endregion

        //    var result = Repository.Instance.InsertSHero(model);

        //    return model.ID;

        //    //???????????

        //    //int maxID = (_models.Count == 0) ? (0) : (_models.Max(x => x.ID));
        //    int maxID;
        //    if (_superHeroes.Count == 0)
        //        maxID = 0;
        //    else
        //        maxID = _superHeroes.Max(x => x.ID);

        //    model.ID = maxID + 1;
        //    _superHeroes.Add(model);

        //    return model.ID;
        //}

        //public int UpdateSHero(int id, SuperHero model)
        //{
        //    #region controlli
        //    if (model == null)
        //        throw new InvalidInputException("null input");

        //    return BadRequest("null model");

        //    if (model.ID == 0 || id != model.ID)
        //        throw new InvalidInputException("null input");

        //    if (index == -1model.ID == 0 || id != model.ID)
        //        throw new InvalidInputException("super hero not found");
        //    #endregion

        //    var result = Repository.Instance.InsertSHero(model);

        //    return model.ID;

        //    //???????????

        //    //int maxID = (_models.Count == 0) ? (0) : (_models.Max(x => x.ID));
        //    int maxID;
        //    if (_superHeroes.Count == 0)
        //        maxID = 0;
        //    else
        //        maxID = _superHeroes.Max(x => x.ID);

        //    model.ID = maxID + 1;
        //    _superHeroes.Add(model);

        //    return model.ID;
        //} 
        #endregion
    }
}