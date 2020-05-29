using Microsoft.EntityFrameworkCore;
using Pandemic.Common.Enums;
using Pandemic.Web.Data.Entities;
using Pandemic.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandemic.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckCountries();
            await CheckCities();
            await CheckStatus();
            await CheckAdmin();
            await CheckEmergency();
            await CheckUser();
            await CheckExampleReportAsync();
        }

        private async Task CheckCities()
        {
            await AddCities("Abejorral ", "Colombia");
            await AddCities("Abriaquí ", "Colombia");
            await AddCities("Acacias ", "Colombia");
            await AddCities("Acandí ", "Colombia");
            await AddCities("Acevedo ", "Colombia");
            await AddCities("Achí ", "Colombia");
            await AddCities("Agrado ", "Colombia");
            await AddCities("Aguachica ", "Colombia");
            await AddCities("Aguada ", "Colombia");
            await AddCities("Aguadas ", "Colombia");
            await AddCities("Aguazul ", "Colombia");
            await AddCities("Agustín Codazzi ", "Colombia");
            await AddCities("Aipe ", "Colombia");
            await AddCities("Albán ", "Colombia");
            await AddCities("Albán ", "Colombia");
            await AddCities("Albania ", "Colombia");
            await AddCities("Albania ", "Colombia");
            await AddCities("Albania ", "Colombia");
            await AddCities("Aldana ", "Colombia");
            await AddCities("Alejandría ", "Colombia");
            await AddCities("Algarrobo ", "Colombia");
            await AddCities("Algeciras ", "Colombia");
            await AddCities("Almaguer ", "Colombia");
            await AddCities("Almeida ", "Colombia");
            await AddCities("Alpujarra ", "Colombia");
            await AddCities("Altamira ", "Colombia");
            await AddCities("Alto Baudo ", "Colombia");
            await AddCities("Alvarado ", "Colombia");
            await AddCities("Amagá ", "Colombia");
            await AddCities("Amalfi ", "Colombia");
            await AddCities("Ambalema ", "Colombia");
            await AddCities("Anapoima ", "Colombia");
            await AddCities("Ancuyá ", "Colombia");
            await AddCities("Andes ", "Colombia");
            await AddCities("Angelópolis ", "Colombia");
            await AddCities("Angostura ", "Colombia");
            await AddCities("Anolaima ", "Colombia");
            await AddCities("Anorí ", "Colombia");
            await AddCities("Anserma ", "Colombia");
            await AddCities("Anza ", "Colombia");
            await AddCities("Anzoátegui ", "Colombia");
            await AddCities("Apartadó ", "Colombia");
            await AddCities("Apía ", "Colombia");
            await AddCities("Apulo ", "Colombia");
            await AddCities("Aquitania ", "Colombia");
            await AddCities("Aracataca ", "Colombia");
            await AddCities("Aranzazu ", "Colombia");
            await AddCities("Aratoca ", "Colombia");
            await AddCities("Arauca ", "Colombia");
            await AddCities("Arauquita ", "Colombia");
            await AddCities("Arbeláez ", "Colombia");
            await AddCities("Arboleda ", "Colombia");
            await AddCities("Arboletes ", "Colombia");
            await AddCities("Arcabuco ", "Colombia");
            await AddCities("Arenal ", "Colombia");
            await AddCities("Argelia ", "Colombia");
            await AddCities("Argelia ", "Colombia");
            await AddCities("Ariguaní ", "Colombia");
            await AddCities("Arjona ", "Colombia");
            await AddCities("Armenia ", "Colombia");
            await AddCities("Armenia ", "Colombia");
            await AddCities("Armero ", "Colombia");
            await AddCities("Arroyohondo ", "Colombia");
            await AddCities("Astrea ", "Colombia");
            await AddCities("Ataco ", "Colombia");
            await AddCities("Atrato ", "Colombia");
            await AddCities("Ayapel ", "Colombia");
            await AddCities("Bagadó ", "Colombia");
            await AddCities("Bahía Solano ", "Colombia");
            await AddCities("Bajo Baudó ", "Colombia");
            await AddCities("Balboa ", "Colombia");
            await AddCities("Balboa ", "Colombia");
            await AddCities("Baranoa ", "Colombia");
            await AddCities("Baraya ", "Colombia");
            await AddCities("Barbacoas ", "Colombia");
            await AddCities("Barbosa ", "Colombia");
            await AddCities("Barbosa ", "Colombia");
            await AddCities("Barichara ", "Colombia");
            await AddCities("Barranca de Upía ", "Colombia");
            await AddCities("Barrancabermeja ", "Colombia");
            await AddCities("Barrancas ", "Colombia");
            await AddCities("Barranco de Loba ", "Colombia");
            await AddCities("Barranco Minas ", "Colombia");
            await AddCities("Barranquilla ", "Colombia");
            await AddCities("Becerril ", "Colombia");
            await AddCities("Belalcázar ", "Colombia");
            await AddCities("Belén ", "Colombia");
            await AddCities("Belén ", "Colombia");
            await AddCities("Belén de Los Andaquies ", "Colombia");
            await AddCities("Bello ", "Colombia");
            await AddCities("Belmira ", "Colombia");
            await AddCities("Beltrán ", "Colombia");
            await AddCities("Berbeo ", "Colombia");
            await AddCities("Betania ", "Colombia");
            await AddCities("Betéitiva ", "Colombia");
            await AddCities("Betulia ", "Colombia");
            await AddCities("Betulia ", "Colombia");
            await AddCities("Bituima ", "Colombia");
            await AddCities("Boavita ", "Colombia");
            await AddCities("Bojacá ", "Colombia");
            await AddCities("Bojaya ", "Colombia");
            await AddCities("Bolívar ", "Colombia");
            await AddCities("Bolívar ", "Colombia");
            await AddCities("Bosconia ", "Colombia");
            await AddCities("Boyacá ", "Colombia");
            await AddCities("Briceño ", "Colombia");
            await AddCities("Briceño ", "Colombia");
            await AddCities("Bucaramanga ", "Colombia");
            await AddCities("Buena Vista ", "Colombia");
            await AddCities("Buenaventura ", "Colombia");
            await AddCities("Buenavista ", "Colombia");
            await AddCities("Buenavista ", "Colombia");
            await AddCities("Buenavista ", "Colombia");
            await AddCities("Buenos Aires ", "Colombia");
            await AddCities("Buesaco ", "Colombia");
            await AddCities("Buriticá ", "Colombia");
            await AddCities("Busbanzá ", "Colombia");
            await AddCities("Cabrera ", "Colombia");
            await AddCities("Cabrera ", "Colombia");
            await AddCities("Cabuyaro ", "Colombia");
            await AddCities("Cacahual ", "Colombia");
            await AddCities("Cáceres ", "Colombia");
            await AddCities("Cachipay ", "Colombia");
            await AddCities("Caicedo ", "Colombia");
            await AddCities("Caimito ", "Colombia");
            await AddCities("Cajamarca ", "Colombia");
            await AddCities("Cajibío ", "Colombia");
            await AddCities("Cajicá ", "Colombia");
            await AddCities("Calamar ", "Colombia");
            await AddCities("Calamar ", "Colombia");
            await AddCities("Calarcá ", "Colombia");
            await AddCities("Caldas ", "Colombia");
            await AddCities("Caldas ", "Colombia");
            await AddCities("Caldono ", "Colombia");
            await AddCities("California ", "Colombia");
            await AddCities("Caloto ", "Colombia");
            await AddCities("Campamento ", "Colombia");
            await AddCities("Campoalegre ", "Colombia");
            await AddCities("Campohermoso ", "Colombia");
            await AddCities("Canalete ", "Colombia");
            await AddCities("Candelaria ", "Colombia");
            await AddCities("Cantagallo ", "Colombia");
            await AddCities("Cañasgordas ", "Colombia");
            await AddCities("Caparrapí ", "Colombia");
            await AddCities("Capitanejo ", "Colombia");
            await AddCities("Caqueza ", "Colombia");
            await AddCities("Caracolí ", "Colombia");
            await AddCities("Caramanta ", "Colombia");
            await AddCities("Carcasí ", "Colombia");
            await AddCities("Carepa ", "Colombia");
            await AddCities("Carmen del Darien ", "Colombia");
            await AddCities("Carolina ", "Colombia");
            await AddCities("Cartagena ", "Colombia");
            await AddCities("Caruru ", "Colombia");
            await AddCities("Casabianca ", "Colombia");
            await AddCities("Castilla la Nueva ", "Colombia");
            await AddCities("Caucasia ", "Colombia");
            await AddCities("Cepitá ", "Colombia");
            await AddCities("Cereté ", "Colombia");
            await AddCities("Cerinza ", "Colombia");
            await AddCities("Cerrito ", "Colombia");
            await AddCities("Cerro San Antonio ", "Colombia");
            await AddCities("Cértegui ", "Colombia");
            await AddCities("Chachagüí ", "Colombia");
            await AddCities("Chaguaní ", "Colombia");
            await AddCities("Chalán ", "Colombia");
            await AddCities("Chámeza ", "Colombia");
            await AddCities("Chaparral ", "Colombia");
            await AddCities("Charalá ", "Colombia");
            await AddCities("Charta ", "Colombia");
            await AddCities("Chía ", "Colombia");
            await AddCities("Chigorodó ", "Colombia");
            await AddCities("Chimá ", "Colombia");
            await AddCities("Chimá ", "Colombia");
            await AddCities("Chimichagua ", "Colombia");
            await AddCities("Chinavita ", "Colombia");
            await AddCities("Chinchiná ", "Colombia");
            await AddCities("Chinú ", "Colombia");
            await AddCities("Chipaque ", "Colombia");
            await AddCities("Chipatá ", "Colombia");
            await AddCities("Chiquinquirá ", "Colombia");
            await AddCities("Chíquiza ", "Colombia");
            await AddCities("Chiriguaná ", "Colombia");
            await AddCities("Chiscas ", "Colombia");
            await AddCities("Chita ", "Colombia");
            await AddCities("Chitaraque ", "Colombia");
            await AddCities("Chivatá ", "Colombia");
            await AddCities("Chivolo ", "Colombia");
            await AddCities("Chivor ", "Colombia");
            await AddCities("Choachí ", "Colombia");
            await AddCities("Chocontá ", "Colombia");
            await AddCities("Cicuco ", "Colombia");
            await AddCities("Ciénaga ", "Colombia");
            await AddCities("Ciénega ", "Colombia");
            await AddCities("Cimitarra ", "Colombia");
            await AddCities("Circasia ", "Colombia");
            await AddCities("Cisneros ", "Colombia");
            await AddCities("Ciudad Bolívar ", "Colombia");
            await AddCities("Clemencia ", "Colombia");
            await AddCities("Cocorná ", "Colombia");
            await AddCities("Coello ", "Colombia");
            await AddCities("Cogua ", "Colombia");
            await AddCities("Colombia ", "Colombia");
            await AddCities("Colón ", "Colombia");
            await AddCities("Colón ", "Colombia");
            await AddCities("Coloso ", "Colombia");
            await AddCities("Cómbita ", "Colombia");
            await AddCities("Concepción ", "Colombia");
            await AddCities("Concepción ", "Colombia");
            await AddCities("Concordia ", "Colombia");
            await AddCities("Concordia ", "Colombia");
            await AddCities("Condoto ", "Colombia");
            await AddCities("Confines ", "Colombia");
            await AddCities("Consaca ", "Colombia");
            await AddCities("Contadero ", "Colombia");
            await AddCities("Contratación ", "Colombia");
            await AddCities("Copacabana ", "Colombia");
            await AddCities("Coper ", "Colombia");
            await AddCities("Córdoba ", "Colombia");
            await AddCities("Córdoba ", "Colombia");
            await AddCities("Córdoba ", "Colombia");
            await AddCities("Corinto ", "Colombia");
            await AddCities("Coromoro ", "Colombia");
            await AddCities("Corozal ", "Colombia");
            await AddCities("Corrales ", "Colombia");
            await AddCities("Cota ", "Colombia");
            await AddCities("Cotorra ", "Colombia");
            await AddCities("Covarachía ", "Colombia");
            await AddCities("Coveñas ", "Colombia");
            await AddCities("Coyaima ", "Colombia");
            await AddCities("Cravo Norte ", "Colombia");
            await AddCities("Cuaspud ", "Colombia");
            await AddCities("Cubará ", "Colombia");
            await AddCities("Cubarral ", "Colombia");
            await AddCities("Cucaita ", "Colombia");
            await AddCities("Cucunubá ", "Colombia");
            await AddCities("Cúcuta ", "Colombia");
            await AddCities("Cuítiva ", "Colombia");
            await AddCities("Cumaral ", "Colombia");
            await AddCities("Cumaribo ", "Colombia");
            await AddCities("Cumbal ", "Colombia");
            await AddCities("Cumbitara ", "Colombia");
            await AddCities("Cunday ", "Colombia");
            await AddCities("Curillo ", "Colombia");
            await AddCities("Curití ", "Colombia");
            await AddCities("Curumaní ", "Colombia");
            await AddCities("Dabeiba ", "Colombia");
            await AddCities("Dibula ", "Colombia");
            await AddCities("Distracción ", "Colombia");
            await AddCities("Dolores ", "Colombia");
            await AddCities("Don Matías ", "Colombia");
            await AddCities("Dosquebradas ", "Colombia");
            await AddCities("Duitama ", "Colombia");
            await AddCities("Ebéjico ", "Colombia");
            await AddCities("El Bagre ", "Colombia");
            await AddCities("El Banco ", "Colombia");
            await AddCities("El Calvario ", "Colombia");
            await AddCities("El Cantón del San Pablo ", "Colombia");
            await AddCities("El Carmen ", "Colombia");
            await AddCities("El Castillo ", "Colombia");
            await AddCities("El Charco ", "Colombia");
            await AddCities("El Cocuy ", "Colombia");
            await AddCities("El Colegio ", "Colombia");
            await AddCities("El Copey ", "Colombia");
            await AddCities("El Doncello ", "Colombia");
            await AddCities("El Dorado ", "Colombia");
            await AddCities("El Encanto ", "Colombia");
            await AddCities("El Espino ", "Colombia");
            await AddCities("El Guacamayo ", "Colombia");
            await AddCities("El Guamo ", "Colombia");
            await AddCities("El Litoral del San Juan ", "Colombia");
            await AddCities("El Molino ", "Colombia");
            await AddCities("El Paso ", "Colombia");
            await AddCities("El Paujil ", "Colombia");
            await AddCities("El Peñol ", "Colombia");
            await AddCities("El Peñón ", "Colombia");
            await AddCities("El Peñón ", "Colombia");
            await AddCities("El Peñón ", "Colombia");
            await AddCities("El Piñon ", "Colombia");
            await AddCities("El Playón ", "Colombia");
            await AddCities("El Retén ", "Colombia");
            await AddCities("El Roble ", "Colombia");
            await AddCities("El Rosal ", "Colombia");
            await AddCities("El Rosario ", "Colombia");
            await AddCities("El Santuario ", "Colombia");
            await AddCities("El Tambo ", "Colombia");
            await AddCities("El Tambo ", "Colombia");
            await AddCities("Elías ", "Colombia");
            await AddCities("Encino ", "Colombia");
            await AddCities("Enciso ", "Colombia");
            await AddCities("Entrerrios ", "Colombia");
            await AddCities("Envigado ", "Colombia");
            await AddCities("Espinal ", "Colombia");
            await AddCities("Facatativá ", "Colombia");
            await AddCities("Falan ", "Colombia");
            await AddCities("Filadelfia ", "Colombia");
            await AddCities("Filandia ", "Colombia");
            await AddCities("Firavitoba ", "Colombia");
            await AddCities("Flandes ", "Colombia");
            await AddCities("Florencia ", "Colombia");
            await AddCities("Florencia ", "Colombia");
            await AddCities("Floresta ", "Colombia");
            await AddCities("Florián ", "Colombia");
            await AddCities("Florida ", "Colombia");
            await AddCities("Floridablanca ", "Colombia");
            await AddCities("Fomeque ", "Colombia");
            await AddCities("Fonseca ", "Colombia");
            await AddCities("Fortul ", "Colombia");
            await AddCities("Fosca ", "Colombia");
            await AddCities("Francisco Pizarro ", "Colombia");
            await AddCities("Fredonia ", "Colombia");
            await AddCities("Fresno ", "Colombia");
            await AddCities("Frontino ", "Colombia");
            await AddCities("Fuente de Oro ", "Colombia");
            await AddCities("Fundación ", "Colombia");
            await AddCities("Funes ", "Colombia");
            await AddCities("Funza ", "Colombia");
            await AddCities("Fúquene ", "Colombia");
            await AddCities("Fusagasugá ", "Colombia");
            await AddCities("Gachala ", "Colombia");
            await AddCities("Gachancipá ", "Colombia");
            await AddCities("Gachantivá ", "Colombia");
            await AddCities("Gachetá ", "Colombia");
            await AddCities("Galán ", "Colombia");
            await AddCities("Galapa ", "Colombia");
            await AddCities("Galeras ", "Colombia");
            await AddCities("Gama ", "Colombia");
            await AddCities("Gamarra ", "Colombia");
            await AddCities("Gambita ", "Colombia");
            await AddCities("Gameza ", "Colombia");
            await AddCities("Garagoa ", "Colombia");
            await AddCities("Garzón ", "Colombia");
            await AddCities("Génova ", "Colombia");
            await AddCities("Gigante ", "Colombia");
            await AddCities("Giraldo ", "Colombia");
            await AddCities("Girardot ", "Colombia");
            await AddCities("Girardota ", "Colombia");
            await AddCities("Girón ", "Colombia");
            await AddCities("Gómez Plata ", "Colombia");
            await AddCities("González ", "Colombia");
            await AddCities("Granada ", "Colombia");
            await AddCities("Granada ", "Colombia");
            await AddCities("Granada ", "Colombia");
            await AddCities("Guaca ", "Colombia");
            await AddCities("Guacamayas ", "Colombia");
            await AddCities("Guachené ", "Colombia");
            await AddCities("Guachetá ", "Colombia");
            await AddCities("Guachucal ", "Colombia");
            await AddCities("Guadalupe ", "Colombia");
            await AddCities("Guadalupe ", "Colombia");
            await AddCities("Guadalupe ", "Colombia");
            await AddCities("Guaduas ", "Colombia");
            await AddCities("Guaitarilla ", "Colombia");
            await AddCities("Gualmatán ", "Colombia");
            await AddCities("Guamal ", "Colombia");
            await AddCities("Guamal ", "Colombia");
            await AddCities("Guamo ", "Colombia");
            await AddCities("Guapi ", "Colombia");
            await AddCities("Guapotá ", "Colombia");
            await AddCities("Guaranda ", "Colombia");
            await AddCities("Guarne ", "Colombia");
            await AddCities("Guasca ", "Colombia");
            await AddCities("Guatapé ", "Colombia");
            await AddCities("Guataquí ", "Colombia");
            await AddCities("Guatavita ", "Colombia");
            await AddCities("Guateque ", "Colombia");
            await AddCities("Guática ", "Colombia");
            await AddCities("Guavatá ", "Colombia");
            await AddCities("Guayabal de Siquima ", "Colombia");
            await AddCities("Guayabetal ", "Colombia");
            await AddCities("Guayatá ", "Colombia");
            await AddCities("Güepsa ", "Colombia");
            await AddCities("Güicán ", "Colombia");
            await AddCities("Gutiérrez ", "Colombia");
            await AddCities("Hatillo de Loba ", "Colombia");
            await AddCities("Hato Corozal ", "Colombia");
            await AddCities("Hatonuevo ", "Colombia");
            await AddCities("Heliconia ", "Colombia");
            await AddCities("Herveo ", "Colombia");
            await AddCities("Hispania ", "Colombia");
            await AddCities("Hobo ", "Colombia");
            await AddCities("Honda ", "Colombia");
            await AddCities("Ibagué ", "Colombia");
            await AddCities("Icononzo ", "Colombia");
            await AddCities("Iles ", "Colombia");
            await AddCities("Imués ", "Colombia");
            await AddCities("Inírida ", "Colombia");
            await AddCities("Inzá ", "Colombia");
            await AddCities("Ipiales ", "Colombia");
            await AddCities("Iquira ", "Colombia");
            await AddCities("Isnos ", "Colombia");
            await AddCities("Istmina ", "Colombia");
            await AddCities("Itagui ", "Colombia");
            await AddCities("Ituango ", "Colombia");
            await AddCities("Iza ", "Colombia");
            await AddCities("Jambaló ", "Colombia");
            await AddCities("Jamundí ", "Colombia");
            await AddCities("Jardín ", "Colombia");
            await AddCities("Jenesano ", "Colombia");
            await AddCities("Jericó ", "Colombia");
            await AddCities("Jericó ", "Colombia");
            await AddCities("Jerusalén ", "Colombia");
            await AddCities("Jesús María ", "Colombia");
            await AddCities("Jordán ", "Colombia");
            await AddCities("Juan de Acosta ", "Colombia");
            await AddCities("Junín ", "Colombia");
            await AddCities("Juradó ", "Colombia");
            await AddCities("La Apartada ", "Colombia");
            await AddCities("La Argentina ", "Colombia");
            await AddCities("La Belleza ", "Colombia");
            await AddCities("La Calera ", "Colombia");
            await AddCities("La Capilla ", "Colombia");
            await AddCities("La Ceja ", "Colombia");
            await AddCities("La Celia ", "Colombia");
            await AddCities("La Chorrera ", "Colombia");
            await AddCities("La Cruz ", "Colombia");
            await AddCities("La Dorada ", "Colombia");
            await AddCities("La Estrella ", "Colombia");
            await AddCities("La Florida ", "Colombia");
            await AddCities("La Gloria ", "Colombia");
            await AddCities("La Guadalupe ", "Colombia");
            await AddCities("La Jagua de Ibirico ", "Colombia");
            await AddCities("La Jagua del Pilar ", "Colombia");
            await AddCities("La Llanada ", "Colombia");
            await AddCities("La Macarena ", "Colombia");
            await AddCities("La Merced ", "Colombia");
            await AddCities("La Mesa ", "Colombia");
            await AddCities("La Montañita ", "Colombia");
            await AddCities("La Palma ", "Colombia");
            await AddCities("La Paz ", "Colombia");
            await AddCities("La Paz ", "Colombia");
            await AddCities("La Pedrera ", "Colombia");
            await AddCities("La Peña ", "Colombia");
            await AddCities("La Pintada ", "Colombia");
            await AddCities("La Plata ", "Colombia");
            await AddCities("La Primavera ", "Colombia");
            await AddCities("La Salina ", "Colombia");
            await AddCities("La Sierra ", "Colombia");
            await AddCities("La Tebaida ", "Colombia");
            await AddCities("La Tola ", "Colombia");
            await AddCities("La Unión ", "Colombia");
            await AddCities("La Unión ", "Colombia");
            await AddCities("La Unión ", "Colombia");
            await AddCities("La Uvita ", "Colombia");
            await AddCities("La Vega ", "Colombia");
            await AddCities("La Vega ", "Colombia");
            await AddCities("La Victoria ", "Colombia");
            await AddCities("La Victoria ", "Colombia");
            await AddCities("La Virginia ", "Colombia");
            await AddCities("Labranzagrande ", "Colombia");
            await AddCities("Landázuri ", "Colombia");
            await AddCities("Lebríja ", "Colombia");
            await AddCities("Leguízamo ", "Colombia");
            await AddCities("Leiva ", "Colombia");
            await AddCities("Lejanías ", "Colombia");
            await AddCities("Lenguazaque ", "Colombia");
            await AddCities("Lérida ", "Colombia");
            await AddCities("Leticia ", "Colombia");
            await AddCities("Líbano ", "Colombia");
            await AddCities("Liborina ", "Colombia");
            await AddCities("Linares ", "Colombia");
            await AddCities("Lloró ", "Colombia");
            await AddCities("López ", "Colombia");
            await AddCities("Lorica ", "Colombia");
            await AddCities("Los Andes ", "Colombia");
            await AddCities("Los Córdobas ", "Colombia");
            await AddCities("Los Palmitos ", "Colombia");
            await AddCities("Los Santos ", "Colombia");
            await AddCities("Luruaco ", "Colombia");
            await AddCities("Macanal ", "Colombia");
            await AddCities("Macaravita ", "Colombia");
            await AddCities("Maceo ", "Colombia");
            await AddCities("Macheta ", "Colombia");
            await AddCities("Madrid ", "Colombia");
            await AddCities("Magangué ", "Colombia");
            await AddCities("Magüí ", "Colombia");
            await AddCities("Mahates ", "Colombia");
            await AddCities("Maicao ", "Colombia");
            await AddCities("Majagual ", "Colombia");
            await AddCities("Málaga ", "Colombia");
            await AddCities("Malambo ", "Colombia");
            await AddCities("Mallama ", "Colombia");
            await AddCities("Manatí ", "Colombia");
            await AddCities("Manaure ", "Colombia");
            await AddCities("Manaure ", "Colombia");
            await AddCities("Maní ", "Colombia");
            await AddCities("Manizales ", "Colombia");
            await AddCities("Manta ", "Colombia");
            await AddCities("Manzanares ", "Colombia");
            await AddCities("Mapiripán ", "Colombia");
            await AddCities("Mapiripana ", "Colombia");
            await AddCities("Margarita ", "Colombia");
            await AddCities("María la Baja ", "Colombia");
            await AddCities("Marinilla ", "Colombia");
            await AddCities("Maripí ", "Colombia");
            await AddCities("Mariquita ", "Colombia");
            await AddCities("Marmato ", "Colombia");
            await AddCities("Marquetalia ", "Colombia");
            await AddCities("Marsella ", "Colombia");
            await AddCities("Marulanda ", "Colombia");
            await AddCities("Matanza ", "Colombia");
            await AddCities("Medellin ", "Colombia");
            await AddCities("Medina ", "Colombia");
            await AddCities("Medio Atrato ", "Colombia");
            await AddCities("Medio Baudó ", "Colombia");
            await AddCities("Medio San Juan ", "Colombia");
            await AddCities("Melgar ", "Colombia");
            await AddCities("Mercaderes ", "Colombia");
            await AddCities("Mesetas ", "Colombia");
            await AddCities("Milán ", "Colombia");
            await AddCities("Miraflores ", "Colombia");
            await AddCities("Miraflores ", "Colombia");
            await AddCities("Miranda ", "Colombia");
            await AddCities("Miriti Paraná ", "Colombia");
            await AddCities("Mistrató ", "Colombia");
            await AddCities("Mitú ", "Colombia");
            await AddCities("Mocoa ", "Colombia");
            await AddCities("Mogotes ", "Colombia");
            await AddCities("Molagavita ", "Colombia");
            await AddCities("Momil ", "Colombia");
            await AddCities("Mompós ", "Colombia");
            await AddCities("Mongua ", "Colombia");
            await AddCities("Monguí ", "Colombia");
            await AddCities("Moniquirá ", "Colombia");
            await AddCities("Montebello ", "Colombia");
            await AddCities("Montecristo ", "Colombia");
            await AddCities("Montelíbano ", "Colombia");
            await AddCities("Montenegro ", "Colombia");
            await AddCities("Montería ", "Colombia");
            await AddCities("Monterrey ", "Colombia");
            await AddCities("Moñitos ", "Colombia");
            await AddCities("Morales ", "Colombia");
            await AddCities("Morales ", "Colombia");
            await AddCities("Morelia ", "Colombia");
            await AddCities("Morichal ", "Colombia");
            await AddCities("Morroa ", "Colombia");
            await AddCities("Mosquera ", "Colombia");
            await AddCities("Mosquera ", "Colombia");
            await AddCities("Motavita ", "Colombia");
            await AddCities("Murillo ", "Colombia");
            await AddCities("Murindó ", "Colombia");
            await AddCities("Mutatá ", "Colombia");
            await AddCities("Muzo ", "Colombia");
            await AddCities("Nariño ", "Colombia");
            await AddCities("Nariño ", "Colombia");
            await AddCities("Nariño ", "Colombia");
            await AddCities("Nátaga ", "Colombia");
            await AddCities("Natagaima ", "Colombia");
            await AddCities("Nechí ", "Colombia");
            await AddCities("Necoclí ", "Colombia");
            await AddCities("Neira ", "Colombia");
            await AddCities("Neiva ", "Colombia");
            await AddCities("Nemocón ", "Colombia");
            await AddCities("Nilo ", "Colombia");
            await AddCities("Nimaima ", "Colombia");
            await AddCities("Nobsa ", "Colombia");
            await AddCities("Nocaima ", "Colombia");
            await AddCities("Norcasia ", "Colombia");
            await AddCities("Norosí ", "Colombia");
            await AddCities("Nóvita ", "Colombia");
            await AddCities("Nueva Granada ", "Colombia");
            await AddCities("Nuevo Colón ", "Colombia");
            await AddCities("Nunchía ", "Colombia");
            await AddCities("Nuquí ", "Colombia");
            await AddCities("Ocamonte ", "Colombia");
            await AddCities("Oiba ", "Colombia");
            await AddCities("Oicatá ", "Colombia");
            await AddCities("Olaya ", "Colombia");
            await AddCities("Olaya Herrera ", "Colombia");
            await AddCities("Onzaga ", "Colombia");
            await AddCities("Oporapa ", "Colombia");
            await AddCities("Orito ", "Colombia");
            await AddCities("Orocué ", "Colombia");
            await AddCities("Ortega ", "Colombia");
            await AddCities("Ospina ", "Colombia");
            await AddCities("Otanche ", "Colombia");
            await AddCities("Ovejas ", "Colombia");
            await AddCities("Pachavita ", "Colombia");
            await AddCities("Pacho ", "Colombia");
            await AddCities("Pacoa ", "Colombia");
            await AddCities("Pácora ", "Colombia");
            await AddCities("Padilla ", "Colombia");
            await AddCities("Páez ", "Colombia");
            await AddCities("Páez ", "Colombia");
            await AddCities("Paicol ", "Colombia");
            await AddCities("Pailitas ", "Colombia");
            await AddCities("Paime ", "Colombia");
            await AddCities("Paipa ", "Colombia");
            await AddCities("Pajarito ", "Colombia");
            await AddCities("Palermo ", "Colombia");
            await AddCities("Palestina ", "Colombia");
            await AddCities("Palestina ", "Colombia");
            await AddCities("Palmar ", "Colombia");
            await AddCities("Palmar de Varela ", "Colombia");
            await AddCities("Palmas del Socorro ", "Colombia");
            await AddCities("Palmito ", "Colombia");
            await AddCities("Palocabildo ", "Colombia");
            await AddCities("Pamplona ", "Colombia");
            await AddCities("Pamplonita ", "Colombia");
            await AddCities("Pana Pana ", "Colombia");
            await AddCities("Pandi ", "Colombia");
            await AddCities("Panqueba ", "Colombia");
            await AddCities("Papunaua ", "Colombia");
            await AddCities("Páramo ", "Colombia");
            await AddCities("Paratebueno ", "Colombia");
            await AddCities("Pasca ", "Colombia");
            await AddCities("Pasto ", "Colombia");
            await AddCities("Patía ", "Colombia");
            await AddCities("Pauna ", "Colombia");
            await AddCities("Paya ", "Colombia");
            await AddCities("Paz de Ariporo ", "Colombia");
            await AddCities("Paz de Río ", "Colombia");
            await AddCities("Pedraza ", "Colombia");
            await AddCities("Pelaya ", "Colombia");
            await AddCities("Pensilvania ", "Colombia");
            await AddCities("Peñol ", "Colombia");
            await AddCities("Peque ", "Colombia");
            await AddCities("Pereira ", "Colombia");
            await AddCities("Pesca ", "Colombia");
            await AddCities("Piamonte ", "Colombia");
            await AddCities("Piedecuesta ", "Colombia");
            await AddCities("Piedras ", "Colombia");
            await AddCities("Piendamó ", "Colombia");
            await AddCities("Pijao ", "Colombia");
            await AddCities("Pinchote ", "Colombia");
            await AddCities("Pinillos ", "Colombia");
            await AddCities("Piojó ", "Colombia");
            await AddCities("Pisba ", "Colombia");
            await AddCities("Pital ", "Colombia");
            await AddCities("Pitalito ", "Colombia");
            await AddCities("Pivijay ", "Colombia");
            await AddCities("Planadas ", "Colombia");
            await AddCities("Planeta Rica ", "Colombia");
            await AddCities("Plato ", "Colombia");
            await AddCities("Policarpa ", "Colombia");
            await AddCities("Polonuevo ", "Colombia");
            await AddCities("Ponedera ", "Colombia");
            await AddCities("Popayán ", "Colombia");
            await AddCities("Pore ", "Colombia");
            await AddCities("Potosí ", "Colombia");
            await AddCities("Prado ", "Colombia");
            await AddCities("Providencia ", "Colombia");
            await AddCities("Providencia ", "Colombia");
            await AddCities("Pueblo Bello ", "Colombia");
            await AddCities("Pueblo Nuevo ", "Colombia");
            await AddCities("Pueblo Rico ", "Colombia");
            await AddCities("Pueblo Viejo ", "Colombia");
            await AddCities("Pueblorrico ", "Colombia");
            await AddCities("Puente Nacional ", "Colombia");
            await AddCities("Puerres ", "Colombia");
            await AddCities("Puerto Arica ", "Colombia");
            await AddCities("Puerto Asís ", "Colombia");
            await AddCities("Puerto Berrío ", "Colombia");
            await AddCities("Puerto Boyacá ", "Colombia");
            await AddCities("Puerto Caicedo ", "Colombia");
            await AddCities("Puerto Carreño ", "Colombia");
            await AddCities("Puerto Colombia ", "Colombia");
            await AddCities("Puerto Colombia ", "Colombia");
            await AddCities("Puerto Concordia ", "Colombia");
            await AddCities("Puerto Escondido ", "Colombia");
            await AddCities("Puerto Gaitán ", "Colombia");
            await AddCities("Puerto Guzmán ", "Colombia");
            await AddCities("Puerto Libertador ", "Colombia");
            await AddCities("Puerto Lleras ", "Colombia");
            await AddCities("Puerto López ", "Colombia");
            await AddCities("Puerto Nare ", "Colombia");
            await AddCities("Puerto Nariño ", "Colombia");
            await AddCities("Puerto Parra ", "Colombia");
            await AddCities("Puerto Rico ", "Colombia");
            await AddCities("Puerto Rico ", "Colombia");
            await AddCities("Puerto Rondón ", "Colombia");
            await AddCities("Puerto Salgar ", "Colombia");
            await AddCities("Puerto Santander ", "Colombia");
            await AddCities("Puerto Tejada ", "Colombia");
            await AddCities("Puerto Triunfo ", "Colombia");
            await AddCities("Puerto Wilches ", "Colombia");
            await AddCities("Pulí ", "Colombia");
            await AddCities("Pupiales ", "Colombia");
            await AddCities("Puracé ", "Colombia");
            await AddCities("Purificación ", "Colombia");
            await AddCities("Purísima ", "Colombia");
            await AddCities("Quebradanegra ", "Colombia");
            await AddCities("Quetame ", "Colombia");
            await AddCities("Quibdó ", "Colombia");
            await AddCities("Quimbaya ", "Colombia");
            await AddCities("Quinchía ", "Colombia");
            await AddCities("Quípama ", "Colombia");
            await AddCities("Quipile ", "Colombia");
            await AddCities("Ramiriquí ", "Colombia");
            await AddCities("Ráquira ", "Colombia");
            await AddCities("Recetor ", "Colombia");
            await AddCities("Regidor ", "Colombia");
            await AddCities("Remedios ", "Colombia");
            await AddCities("Remolino ", "Colombia");
            await AddCities("Repelón ", "Colombia");
            await AddCities("Restrepo ", "Colombia");
            await AddCities("Retiro ", "Colombia");
            await AddCities("Ricaurte ", "Colombia");
            await AddCities("Ricaurte ", "Colombia");
            await AddCities("Rio Blanco ", "Colombia");
            await AddCities("Río de Oro ", "Colombia");
            await AddCities("Río Iro ", "Colombia");
            await AddCities("Río Quito ", "Colombia");
            await AddCities("Río Viejo ", "Colombia");
            await AddCities("Riohacha ", "Colombia");
            await AddCities("Rionegro ", "Colombia");
            await AddCities("Rionegro ", "Colombia");
            await AddCities("Riosucio ", "Colombia");
            await AddCities("Riosucio ", "Colombia");
            await AddCities("Risaralda ", "Colombia");
            await AddCities("Rivera ", "Colombia");
            await AddCities("Roberto Payán ", "Colombia");
            await AddCities("Roncesvalles ", "Colombia");
            await AddCities("Rondón ", "Colombia");
            await AddCities("Rosas ", "Colombia");
            await AddCities("Rovira ", "Colombia");
            await AddCities("Sabanagrande ", "Colombia");
            await AddCities("Sabanalarga ", "Colombia");
            await AddCities("Sabanalarga ", "Colombia");
            await AddCities("Sabanalarga ", "Colombia");
            await AddCities("Sabanas de San Angel ", "Colombia");
            await AddCities("Sabaneta ", "Colombia");
            await AddCities("Saboyá ", "Colombia");
            await AddCities("Sácama ", "Colombia");
            await AddCities("Sáchica ", "Colombia");
            await AddCities("Sahagún ", "Colombia");
            await AddCities("Saladoblanco ", "Colombia");
            await AddCities("Salamina ", "Colombia");
            await AddCities("Salamina ", "Colombia");
            await AddCities("Saldaña ", "Colombia");
            await AddCities("Salento ", "Colombia");
            await AddCities("Salgar ", "Colombia");
            await AddCities("Samacá ", "Colombia");
            await AddCities("Samaná ", "Colombia");
            await AddCities("Samaniego ", "Colombia");
            await AddCities("Sampués ", "Colombia");
            await AddCities("San Alberto ", "Colombia");
            await AddCities("San Andrés ", "Colombia");
            await AddCities("San Andrés de Cuerquía ", "Colombia");
            await AddCities("San Andrés de Tumaco ", "Colombia");
            await AddCities("San Andrés Sotavento ", "Colombia");
            await AddCities("San Antero ", "Colombia");
            await AddCities("San Benito Abad ", "Colombia");
            await AddCities("San Bernardo ", "Colombia");
            await AddCities("San Bernardo ", "Colombia");
            await AddCities("San Bernardo del Viento ", "Colombia");
            await AddCities("San Carlos de Guaroa ", "Colombia");
            await AddCities("San Cayetano ", "Colombia");
            await AddCities("San Cristóbal ", "Colombia");
            await AddCities("San Diego ", "Colombia");
            await AddCities("San Eduardo ", "Colombia");
            await AddCities("San Estanislao ", "Colombia");
            await AddCities("San Felipe ", "Colombia");
            await AddCities("San Fernando ", "Colombia");
            await AddCities("San Francisco ", "Colombia");
            await AddCities("San Francisco ", "Colombia");
            await AddCities("San Francisco ", "Colombia");
            await AddCities("San Gil ", "Colombia");
            await AddCities("San Jerónimo ", "Colombia");
            await AddCities("San Joaquín ", "Colombia");
            await AddCities("San José ", "Colombia");
            await AddCities("San José de Miranda ", "Colombia");
            await AddCities("San José del Fragua ", "Colombia");
            await AddCities("San José del Guaviare ", "Colombia");
            await AddCities("San Juan de Río Seco ", "Colombia");
            await AddCities("San Juan Nepomuceno ", "Colombia");
            await AddCities("San Juanito ", "Colombia");
            await AddCities("San Lorenzo ", "Colombia");
            await AddCities("San Luis ", "Colombia");
            await AddCities("San Luis de Gaceno ", "Colombia");
            await AddCities("San Luis de Gaceno ", "Colombia");
            await AddCities("San Luis de Sincé ", "Colombia");
            await AddCities("San Marcos ", "Colombia");
            await AddCities("San Martín ", "Colombia");
            await AddCities("San Martín ", "Colombia");
            await AddCities("San Mateo ", "Colombia");
            await AddCities("San Miguel ", "Colombia");
            await AddCities("San Miguel ", "Colombia");
            await AddCities("San Onofre ", "Colombia");
            await AddCities("San Pablo ", "Colombia");
            await AddCities("San Pablo de Borbur ", "Colombia");
            await AddCities("San Pedro ", "Colombia");
            await AddCities("San Pedro ", "Colombia");
            await AddCities("San Pedro de Uraba ", "Colombia");
            await AddCities("San Pelayo ", "Colombia");
            await AddCities("San Rafael ", "Colombia");
            await AddCities("San Roque ", "Colombia");
            await AddCities("San Sebastián de Buenavista ", "Colombia");
            await AddCities("San Vicente ", "Colombia");
            await AddCities("San Vicente de Chucurí ", "Colombia");
            await AddCities("San Vicente del Caguán ", "Colombia");
            await AddCities("San Zenón ", "Colombia");
            await AddCities("Sandoná ", "Colombia");
            await AddCities("Santa Ana ", "Colombia");
            await AddCities("Santa Bárbara ", "Colombia");
            await AddCities("Santa Bárbara ", "Colombia");
            await AddCities("Santa Bárbara ", "Colombia");
            await AddCities("Santa Bárbara de Pinto ", "Colombia");
            await AddCities("Santa Catalina ", "Colombia");
            await AddCities("Santa Helena del Opón ", "Colombia");
            await AddCities("Santa Isabel ", "Colombia");
            await AddCities("Santa Lucía ", "Colombia");
            await AddCities("Santa María ", "Colombia");
            await AddCities("Santa María ", "Colombia");
            await AddCities("Santa Marta ", "Colombia");
            await AddCities("Santa Rosa ", "Colombia");
            await AddCities("Santa Rosa ", "Colombia");
            await AddCities("Santa Rosa de Cabal ", "Colombia");
            await AddCities("Santa Rosa de Osos ", "Colombia");
            await AddCities("Santa Rosa de Viterbo ", "Colombia");
            await AddCities("Santa Rosa del Sur ", "Colombia");
            await AddCities("Santa Rosalía ", "Colombia");
            await AddCities("Santa Sofía ", "Colombia");
            await AddCities("Santacruz ", "Colombia");
            await AddCities("Santafé de Antioquia ", "Colombia");
            await AddCities("Santana ", "Colombia");
            await AddCities("Santander de Quilichao ", "Colombia");
            await AddCities("Santiago ", "Colombia");
            await AddCities("Santo Domingo ", "Colombia");
            await AddCities("Santo Tomás ", "Colombia");
            await AddCities("Santuario ", "Colombia");
            await AddCities("Sapuyes ", "Colombia");
            await AddCities("Saravena ", "Colombia");
            await AddCities("Sasaima ", "Colombia");
            await AddCities("Sativanorte ", "Colombia");
            await AddCities("Sativasur ", "Colombia");
            await AddCities("Segovia ", "Colombia");
            await AddCities("Sesquilé ", "Colombia");
            await AddCities("Siachoque ", "Colombia");
            await AddCities("Sibaté ", "Colombia");
            await AddCities("Sibundoy ", "Colombia");
            await AddCities("Silvania ", "Colombia");
            await AddCities("Silvia ", "Colombia");
            await AddCities("Simacota ", "Colombia");
            await AddCities("Simijaca ", "Colombia");
            await AddCities("Simití ", "Colombia");
            await AddCities("Sincelejo ", "Colombia");
            await AddCities("Sipí ", "Colombia");
            await AddCities("Sitionuevo ", "Colombia");
            await AddCities("Soacha ", "Colombia");
            await AddCities("Soatá ", "Colombia");
            await AddCities("Socha ", "Colombia");
            await AddCities("Socorro ", "Colombia");
            await AddCities("Socotá ", "Colombia");
            await AddCities("Sogamoso ", "Colombia");
            await AddCities("Solano ", "Colombia");
            await AddCities("Soledad ", "Colombia");
            await AddCities("Solita ", "Colombia");
            await AddCities("Somondoco ", "Colombia");
            await AddCities("Sonsón ", "Colombia");
            await AddCities("Sopetrán ", "Colombia");
            await AddCities("Soplaviento ", "Colombia");
            await AddCities("Sopó ", "Colombia");
            await AddCities("Sora ", "Colombia");
            await AddCities("Soracá ", "Colombia");
            await AddCities("Sotaquirá ", "Colombia");
            await AddCities("Sotara ", "Colombia");
            await AddCities("Suaita ", "Colombia");
            await AddCities("Suan ", "Colombia");
            await AddCities("Suárez ", "Colombia");
            await AddCities("Suárez ", "Colombia");
            await AddCities("Suaza ", "Colombia");
            await AddCities("Subachoque ", "Colombia");
            await AddCities("Sucre ", "Colombia");
            await AddCities("Sucre ", "Colombia");
            await AddCities("Sucre ", "Colombia");
            await AddCities("Suesca ", "Colombia");
            await AddCities("Supatá ", "Colombia");
            await AddCities("Supía ", "Colombia");
            await AddCities("Suratá ", "Colombia");
            await AddCities("Susa ", "Colombia");
            await AddCities("Susacón ", "Colombia");
            await AddCities("Sutamarchán ", "Colombia");
            await AddCities("Sutatausa ", "Colombia");
            await AddCities("Sutatenza ", "Colombia");
            await AddCities("Tabio ", "Colombia");
            await AddCities("Tadó ", "Colombia");
            await AddCities("Talaigua Nuevo ", "Colombia");
            await AddCities("Tamalameque ", "Colombia");
            await AddCities("Támara ", "Colombia");
            await AddCities("Tame ", "Colombia");
            await AddCities("Támesis ", "Colombia");
            await AddCities("Taminango ", "Colombia");
            await AddCities("Tangua ", "Colombia");
            await AddCities("Taraira ", "Colombia");
            await AddCities("Tarapacá ", "Colombia");
            await AddCities("Tarazá ", "Colombia");
            await AddCities("Tarqui ", "Colombia");
            await AddCities("Tarso ", "Colombia");
            await AddCities("Tasco ", "Colombia");
            await AddCities("Tauramena ", "Colombia");
            await AddCities("Tausa ", "Colombia");
            await AddCities("Tello ", "Colombia");
            await AddCities("Tena ", "Colombia");
            await AddCities("Tenerife ", "Colombia");
            await AddCities("Tenjo ", "Colombia");
            await AddCities("Tenza ", "Colombia");
            await AddCities("Teruel ", "Colombia");
            await AddCities("Tesalia ", "Colombia");
            await AddCities("Tibacuy ", "Colombia");
            await AddCities("Tibaná ", "Colombia");
            await AddCities("Tibasosa ", "Colombia");
            await AddCities("Tibirita ", "Colombia");
            await AddCities("Tierralta ", "Colombia");
            await AddCities("Timaná ", "Colombia");
            await AddCities("Timbío ", "Colombia");
            await AddCities("Timbiquí ", "Colombia");
            await AddCities("Tinjacá ", "Colombia");
            await AddCities("Tipacoque ", "Colombia");
            await AddCities("Tiquisio ", "Colombia");
            await AddCities("Titiribí ", "Colombia");
            await AddCities("Toca ", "Colombia");
            await AddCities("Tocaima ", "Colombia");
            await AddCities("Tocancipá ", "Colombia");
            await AddCities("Togüí ", "Colombia");
            await AddCities("Toledo ", "Colombia");
            await AddCities("Tolú Viejo ", "Colombia");
            await AddCities("Tona ", "Colombia");
            await AddCities("Tópaga ", "Colombia");
            await AddCities("Topaipí ", "Colombia");
            await AddCities("Toribio ", "Colombia");
            await AddCities("Tota ", "Colombia");
            await AddCities("Totoró ", "Colombia");
            await AddCities("Trinidad ", "Colombia");
            await AddCities("Tubará ", "Colombia");
            await AddCities("Tuchín ", "Colombia");
            await AddCities("Tuluá ", "Colombia");
            await AddCities("Tunja ", "Colombia");
            await AddCities("Tununguá ", "Colombia");
            await AddCities("Túquerres ", "Colombia");
            await AddCities("Turbaco ", "Colombia");
            await AddCities("Turbaná ", "Colombia");
            await AddCities("Turbo ", "Colombia");
            await AddCities("Turmequé ", "Colombia");
            await AddCities("Tutazá ", "Colombia");
            await AddCities("Ubalá ", "Colombia");
            await AddCities("Ubaque ", "Colombia");
            await AddCities("Umbita ", "Colombia");
            await AddCities("Une ", "Colombia");
            await AddCities("Unguía ", "Colombia");
            await AddCities("Unión Panamericana ", "Colombia");
            await AddCities("Uramita ", "Colombia");
            await AddCities("Uribe ", "Colombia");
            await AddCities("Uribia ", "Colombia");
            await AddCities("Urrao ", "Colombia");
            await AddCities("Urumita ", "Colombia");
            await AddCities("Usiacurí ", "Colombia");
            await AddCities("Útica ", "Colombia");
            await AddCities("Valdivia ", "Colombia");
            await AddCities("Valencia ", "Colombia");
            await AddCities("Valle de San Juan ", "Colombia");
            await AddCities("Valledupar ", "Colombia");
            await AddCities("Valparaíso ", "Colombia");
            await AddCities("Valparaíso ", "Colombia");
            await AddCities("Vegachí ", "Colombia");
            await AddCities("Vélez ", "Colombia");
            await AddCities("Venadillo ", "Colombia");
            await AddCities("Venecia ", "Colombia");
            await AddCities("Venecia ", "Colombia");
            await AddCities("Ventaquemada ", "Colombia");
            await AddCities("Vetas ", "Colombia");
            await AddCities("Vianí ", "Colombia");
            await AddCities("Victoria ", "Colombia");
            await AddCities("Villa de Leyva ", "Colombia");
            await AddCities("Villa de San Diego de Ubate ", "Colombia");
            await AddCities("Villa Rica ", "Colombia");
            await AddCities("Villagarzón ", "Colombia");
            await AddCities("Villagómez ", "Colombia");
            await AddCities("Villahermosa ", "Colombia");
            await AddCities("Villamaría ", "Colombia");
            await AddCities("Villanueva ", "Colombia");
            await AddCities("Villanueva ", "Colombia");
            await AddCities("Villanueva ", "Colombia");
            await AddCities("Villanueva ", "Colombia");
            await AddCities("Villapinzón ", "Colombia");
            await AddCities("Villarrica ", "Colombia");
            await AddCities("Villavicencio ", "Colombia");
            await AddCities("Villavieja ", "Colombia");
            await AddCities("Villeta ", "Colombia");
            await AddCities("Viotá ", "Colombia");
            await AddCities("Viracachá ", "Colombia");
            await AddCities("Vista Hermosa ", "Colombia");
            await AddCities("Viterbo ", "Colombia");
            await AddCities("Yacopí ", "Colombia");
            await AddCities("Yacuanquer ", "Colombia");
            await AddCities("Yaguará ", "Colombia");
            await AddCities("Yalí ", "Colombia");
            await AddCities("Yarumal ", "Colombia");
            await AddCities("Yavaraté ", "Colombia");
            await AddCities("Yolombó ", "Colombia");
            await AddCities("Yondó ", "Colombia");
            await AddCities("Yopal ", "Colombia");
            await AddCities("Zambrano ", "Colombia");
            await AddCities("Zapatoca ", "Colombia");
            await AddCities("Zapayán ", "Colombia");
            await AddCities("Zaragoza ", "Colombia");
            await AddCities("Zetaquira ", "Colombia");
            await AddCities("Zipacón ", "Colombia");
            await AddCities("Zipaquirá ", "Colombia");
            await AddCities("Zona Bananera ", "Colombia");
            await AddCities("A Coruña ", "España");
            await AddCities("Alava ", "España");
            await AddCities("Albacete ", "España");
            await AddCities("Alicante ", "España");
            await AddCities("Almería ", "España");
            await AddCities("Asturias ", "España");
            await AddCities("Avila ", "España");
            await AddCities("Badajoz ", "España");
            await AddCities("Barcelona ", "España");
            await AddCities("Burgos ", "España");
            await AddCities("Cáceres ", "España");
            await AddCities("Cádiz ", "España");
            await AddCities("Cantabria ", "España");
            await AddCities("Castellón ", "España");
            await AddCities("Ceuta ", "España");
            await AddCities("Ciudad Real ", "España");
            await AddCities("Córdoba ", "España");
            await AddCities("Cuenca ", "España");
            await AddCities("Formentera ", "España");
            await AddCities("Girona ", "España");
            await AddCities("Granada ", "España");
            await AddCities("Guadalajara ", "España");
            await AddCities("Guipuzcoa ", "España");
            await AddCities("Huelva ", "España");
            await AddCities("Huesca ", "España");
            await AddCities("Ibiza ", "España");
            await AddCities("Jaén ", "España");
            await AddCities("La Rioja ", "España");
            await AddCities("Las Palmas de Gran Canaria ", "España");
            await AddCities("Gran Canaria ", "España");
            await AddCities("Fuerteventura ", "España");
            await AddCities("Lanzarote ", "España");
            await AddCities("León ", "España");
            await AddCities("Lérida ", "España");
            await AddCities("Lugo ", "España");
            await AddCities("Madrid ", "España");
            await AddCities("Málaga ", "España");
            await AddCities("Mallorca ", "España");
            await AddCities("Menorca ", "España");
            await AddCities("Murcia ", "España");
            await AddCities("Navarra ", "España");
            await AddCities("Orense ", "España");
            await AddCities("Palencia ", "España");
            await AddCities("Pontevedra ", "España");
            await AddCities("Salamanca ", "España");
            await AddCities("Santa Cruz de Tenerife ", "España");
            await AddCities("Tenerife ", "España");
            await AddCities("La Gomera ", "España");
            await AddCities("La Palma ", "España");
            await AddCities("El Hierro ", "España");
            await AddCities("Segovia ", "España");
            await AddCities("Sevilla ", "España");
            await AddCities("Soria ", "España");
            await AddCities("Tarragona ", "España");
            await AddCities("Teruel ", "España");
            await AddCities("Toledo ", "España");
            await AddCities("Valencia ", "España");
            await AddCities("Valladolid ", "España");
            await AddCities("Vizcaya ", "España");
            await AddCities("Zamora ", "España");
            await AddCities("Zaragoza ", "España");


        }

        private async Task AddCities(string nameCity, string nameCountry)
        {
            var country = await _context.Countries.Where(c => c.Name == nameCountry).FirstOrDefaultAsync();

            if (!await _context.Cities.AnyAsync(c => c.Name == nameCity && c.Country == country))
            {
                var newCity = new Cities()
                {
                    Name = nameCity,
                    Country = country
                };
                await _context.Cities.AddAsync(newCity);
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCountries()
        {
            if (!await _context.Countries.AnyAsync(c => c.Name == "Colombia"))
            {
                var newCountry = new Country()
                {
                    Name = "Colombia"
                };
                await _context.Countries.AddAsync(newCountry);
                await _context.SaveChangesAsync();
            }
            if (!await _context.Countries.AnyAsync(c => c.Name == "España"))
            {
                var newCountry = new Country()
                {
                    Name = "España"
                };
                await _context.Countries.AddAsync(newCountry);
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckStatus()
        {
            await _userHelper.CheckStatusAsync(StatusType.Accepted.ToString());
            await _userHelper.CheckStatusAsync(StatusType.Pending.ToString());
            await _userHelper.CheckStatusAsync(StatusType.Rejected.ToString());
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.Emergency.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckAdmin()
        {
            UserType rol = UserType.Admin;
            await CheckUserAsync("1010", "Nelson", "Palacios", "nelpaga1126@gmail.com", "350 634 2747", "Manrique", rol);
        }

        private async Task CheckEmergency()
        {
            UserType rol = UserType.Emergency;
            await CheckUserAsync("1010", "Laura", "Moreno", "katherin.moreno4@gmail.com", "350 634 2747", "Manrique", rol);
        }

        private async Task CheckUser()
        {
            UserType rol = UserType.User;
            await CheckUserAsync("1010", "Sebastian", "Gomez", "sebastiangomezjimenez8@gmail.com", "350 634 2747", "Manrique", rol);
        }

        private async Task<UserEntity> CheckUserAsync(
        string document,
        string firstName,
        string lastName,
        string email,
        string phone,
        string address,
        UserType userType)
        {
            UserEntity user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                if (user.UserType == UserType.Emergency)
                {
                    UserStatus newUserStatus = new UserStatus()
                    {
                        Status = _context.Status.Where(s => s.Name == StatusType.Accepted.ToString()).FirstOrDefault(),
                        User = user
                    };
                    await _context.UserStatus.AddAsync(newUserStatus);
                    await _context.SaveChangesAsync();
                }
            }
            return user;
        }

        private async Task CheckExampleReportAsync()
        {
            if (!_context.Report.Any())
            {
                _context.Report.Add(
                    new ReportEntity
                    {
                        City = _context.Cities.Where(c => c.Name == "Medellin").FirstOrDefault(),
                        Document = "123456789",
                        FirstName = "Andres",
                        LastName = "Palacio",
                        User = await _userHelper.GetUserAsync("sebastiangomezjimenez8@gmail.com"),
                        ReportDetails = new List<ReportDetailsEntity>
                        {
                          new ReportDetailsEntity
                          {
                              Date = DateTime.Now,
                              Observation = "Esta enfermo",
                              Status = new StatusReport
                              {
                                  Name = "Positive"
                              },
                              User = await _userHelper.GetUserAsync("katherin.moreno4@gmail.com")
                          }
                        }
                    });

                _context.Report.Add(
                   new ReportEntity
                   {
                       City = _context.Cities.Where(c => c.Name == "Valencia").FirstOrDefault(),
                       Document = "123456789",
                       FirstName = "Pepe",
                       LastName = "Palacio",
                       User = await _userHelper.GetUserAsync("sebastiangomezjimenez8@gmail.com"),
                       ReportDetails = new List<ReportDetailsEntity>
                       {
                          new ReportDetailsEntity
                          {
                              Date = DateTime.Now,
                              Observation = "Esta bien",
                              Status = new StatusReport
                              {
                                  Name = "Negative"
                              },
                              User = await _userHelper.GetUserAsync("katherin.moreno4@gmail.com")
                          }
                       }
                   });
                await _context.SaveChangesAsync();
            }
        }
    }
}
