﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class StateLgaMapping
    {
        public static readonly Dictionary<string, List<string>> Mappings = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
        {
            { "ABIA", new List<string> { "ABA NORTH", "ABA SOUTH", "AROCHUKWU", "BENDE", "IKWUANO", "ISIALA NGWA NORTH", "ISIALA NGWA SOUTH", "ISUIKWUATO", "OBI NGWA", "OHAFIA", "OSISIOMA", "UGWUNAGBO", "UKWA EAST", "UKWA WEST", "UMUAHIA NORTH", "UMUAHIA SOUTH", "UMU NNEOCHI" } },
            { "ADAMAWA", new List<string> { "DEMSA", "FUFORE", "GANYE", "GAYUK", "GOMBI", "GRIE", "HONG", "JADA", "LAMURDE", "MADAGALI", "MAIHA", "MAYO-BELWA", "MICHIKA", "MUBI NORTH", "MUBI SOUTH", "NUMAN", "SHELLENG", "SONG", "TOUNGO", "YOLA NORTH", "YOLA SOUTH" } },
            { "AKWA IBOM", new List<string> { "ABAK", "EASTERN OBOLO", "EKET", "ESIT EKET", "ESSIEN UDIM", "ETIM EKPO", "ETINAN", "IBENO", "IBESIKPO ASUTAN", "IBIONO-IBOM", "IKA", "IKONO", "IKOT ABASI", "IKOT EKPENE", "INI", "ITU", "MBO", "MKPAT-ENIN", "NSIT-ATAI", "NSIT-IBOM", "NSIT-UBIUM", "OBOT AKARA", "OKOBO", "ONNA", "ORON", "ORUK ANAM", "UDUNG-UKO", "UKANAFUN", "URUAN", "URUE-OFFONG/ORUKO", "UYO" } },
            { "ANAMBRA", new List<string> { "AGUATA", "ANAMBRA EAST", "ANAMBRA WEST", "ANAOCHA", "AWKA NORTH", "AWKA SOUTH", "AYAMELUM", "DUNUKOFIA", "EKWUSIGO", "IDEMILI NORTH", "IDEMILI SOUTH", "IHIALA", "NJIKOKA", "NNEWI NORTH", "NNEWI SOUTH", "OGBARU", "ONITSHA NORTH", "ONITSHA SOUTH", "ORUMBA NORTH", "ORUMBA SOUTH", "OYI" } },
            { "BAUCHI", new List<string> { "ALKALERI", "BAUCHI", "BOGORO", "DAMBAN", "DARAZO", "DASS", "GANJUWA", "GIADE", "ITAS/GADAU", "JAMA'ARE", "KATAGUM", "KIRFI", "MISAU", "NINGI", "SHIRA", "TAFAWA BALEWA", "TORO", "WARJI", "ZAKI" } },
            { "BAYELSA", new List<string> { "BRASS", "EKEREMOR", "KOLOKUMA/OPOKUMA", "NEMBE", "OGBIA", "SAGBAMA", "SOUTHERN IJAW", "YENAGOA" } },
            { "BENUE", new List<string> { "ADO", "AGATU", "APA", "BURUKU", "GBOKO", "GUMA", "GWER EAST", "GWER WEST", "KATSINA-ALA", "KONSHISHA", "KWANDE", "LOGO", "MAKURDI", "OBI", "OGBADIBO", "OHIMINI", "OJU", "OKPOKWU", "OTUKPO", "TARKA", "UKUM", "USHONGO", "VANDEIKYA" } },
            { "BORNO", new List<string> { "ABADAM", "ASKIRA/UBA", "BAMA", "BAYO", "BIU", "CHIBOK", "DAMBOA", "DIKWA", "GUBIO", "GUZAMALA", "GWOZA", "HAWUL", "JERE", "KAGA", "KALA/BALGE", "KONDUGA", "KUKAWA", "KWAYA KUSAR", "MAFA", "MAGUMERI", "MAIDUGURI", "MARTE", "MOBBAR", "MONGUNO", "NGALA", "NGANZAI", "SHANI" } },
            { "CROSS RIVER", new List<string> { "ABI", "AKAMKPA", "AKPABUYO", "BAKASSI", "BEKWARRA", "BIASE", "BOKI", "CALABAR MUNICIPAL", "CALABAR SOUTH", "ETUNG", "IKOM", "OBANLIKU", "OBUBRA", "OBUDU", "ODUKPANI", "OGOJA", "YAKUUR", "YALA" } },
            { "DELTA", new List<string> { "ANIOCHA NORTH", "ANIOCHA SOUTH", "BOMADI", "BURUTU", "ETHIOPE EAST", "ETHIOPE WEST", "IKA NORTH EAST", "IKA SOUTH", "ISOKO NORTH", "ISOKO SOUTH", "NDOKWA EAST", "NDOKWA WEST", "OKPE", "OSHIMILI NORTH", "OSHIMILI SOUTH", "PATANI", "SAPELE", "UDU", "UGHELLI NORTH", "UGHELLI SOUTH", "UKWUANI", "UVWIE", "WARRI NORTH", "WARRI SOUTH", "WARRI SOUTH WEST" } },
            { "EBONYI", new List<string> { "ABAKALIKI", "AFIKPO NORTH", "AFIKPO SOUTH", "EBONYI", "EZZA NORTH", "EZZA SOUTH", "IKWO", "ISHIELU", "IVO", "IZZI", "OHAOZARA", "OHAUKWU", "ONICHA" } },
            { "EDO", new List<string> { "AKOKO-EDO", "EGOR", "ESAN CENTRAL", "ESAN NORTH-EAST", "ESAN SOUTH-EAST", "ESAN WEST", "ETSAKO CENTRAL", "ETSAKO EAST", "ETSAKO WEST", "IGUEBEN", "IKPOBA-OKHA", "OREODU", "ORHIONMWON", "OVIA NORTH-EAST", "OVIA SOUTH-WEST", "OWAN EAST", "OWAN WEST", "UHUNMWONDE" } },
            { "EKITI", new List<string> { "ADO EKITI", "EFON", "EKITI EAST", "EKITI SOUTH-WEST", "EKITI WEST", "EMURE", "GBONYIN", "IDO OSI", "IJERO", "IKERE", "IKOLE", "ILEJEMEJE", "IREPODUN/IFELODUN", "ISE/ORUN", "MOBA", "OYE" } },
            { "ENUGU", new List<string> { "ANINRI", "AWGU", "ENUGU EAST", "ENUGU NORTH", "ENUGU SOUTH", "EZEAGU", "IGBO ETITI", "IGBO EZE NORTH", "IGBO EZE SOUTH", "ISI UZO", "NKANU EAST", "NKANU WEST", "NSUKKA", "OJI RIVER", "UDENU", "UDI", "UZO-UWANI" } },
            { "GOMBE", new List<string> { "AKKO", "BALANGA", "BILLIRI", "DUKKU", "FUNAKAYE", "GOMBE", "KALTUNGO", "KWAMI", "NAFADA", "SHONGOM", "YAMALTU/DEBA" } },
            { "IMO", new List<string> { "ABOH MBAISE", "AHIAZU MBAISE", "EHIME MBANO", "EZINIHITTE", "IDEATO NORTH", "IDEATO SOUTH", "IHITTE/UBOMA", "IKEDURU", "ISIALA MBANO", "ISU", "MBAITOLI", "NGOR OKPALA", "NJABA", "NKWERRE", "NWANGELE", "OBOWO", "OGUTA", "OHAJI/EGBEMA", "OKIGWE", "ONUIMO", "ORLU", "ORSU", "OWERRI MUNICIPAL", "OWERRI NORTH", "OWERRI WEST" } },
            { "JIGAWA", new List<string> { "AUYO", "BABURA", "BIRINIWA", "BIRNIN KUDU", "BUJI", "DUTSE", "GAGARAWA", "GARKI", "GUMEL", "GURI", "GWARAM", "GWIWA", "HADEJIA", "JAHUN", "KAFIN HAUSA", "KAUGAMA", "KAZAURE", "KIRIKASAMMA", "KIYAWA", "MAIGATARI", "MALAM MADORI", "MIGA", "RINGIM", "RONI", "SULE TANKARKAR", "TAURA", "YANKWASHI" } },
            { "KADUNA", new List<string> { "BIRNIN GWARI", "CHIKUN", "GIWA", "IGABI", "IKARA", "JABA", "JEMA'A", "KACHIA", "KADUNA NORTH", "KADUNA SOUTH", "KAGARKO", "KAJURU", "KAURA", "KAURU", "KUBAU", "KUDAN", "LERE", "MAKARFI", "SABON GARI", "SANGA", "SOBA", "ZANGON KATAF", "ZARIA" } },
            { "KANO", new List<string> { "AJINGI", "ALBASU", "BAGWAI", "BEBEJI", "BICHI", "BUNKURE", "DALA", "DAMBATTA", "DAWAKIN KUDU", "DAWAKIN TOFA", "DOGUWA", "FAGGE", "GABASAWA", "GARKO", "GARUN MALLAM", "GAYA", "GEZAWA", "GWALE", "GWARZO", "KABO", "KANO MUNICIPAL", "KARAYE", "KIBIYA", "KIRU", "KUMBOTSO", "KUNCHI", "KURA", "MADOBI", "MAKODA", "MINJIBIR", "NASARAWA", "RANO", "RIMIN GADO", "ROGO", "SHANONO", "SUMAILA", "TAKAI", "TARAUNI", "TOFA", "TSANYAWA", "TUDUN WADA", "UNGOGO", "WARAWA", "WUDIL" } },
            { "KATSINA", new List<string> { "BAKORI", "BATAGARAWA", "BATSARI", "BAURE", "BINDAWA", "CHARANCHI", "DAN MUSA", "DANDUME", "DANJA", "DAURA", "DUTSI", "DUTSIN MA", "FASKARI", "FUNTUA", "INGAWA", "JIBIA", "KAFUR", "KAITA", "KANKARA", "KANKIA", "KATSINA", "KURFI", "KUSADA", "MAI'ADUA", "MALUMFASHI", "MANI", "MASHI", "MATAZU", "MUSAWA", "RIMI", "SABUWA", "SAFANA", "SANDAMU", "ZANGO" } },
            { "KEBBI", new List<string> { "ALEIRO", "AREWA DANDI", "ARGUNGU", "AUGIE", "BAGUDO", "BIRNIN KEBBI", "BUNZA", "DANDI", "FAKAI", "GWANDU", "JEGA", "KALGO", "KOKO/BESSE", "MAIYAMA", "NGASKI", "SAKABA", "SHANGA", "SURU", "DANKO-WASAGU", "YAURI", "ZURU" } },
            { "KOGI", new List<string> { "ADAVI", "AJAOKUTA", "ANKPA", "BASSA", "DEKINA", "IBAJI", "IDAH", "IGALAMELA ODOLU", "IJUMU", "KABBA/BUNU", "KOGI", "LOKOJA", "MOPA MURO", "OFU", "OGORI/MAGONGO", "OKEHI", "OKENE", "OLAMABORO", "OMALA", "YAGBA EAST", "YAGBA WEST" } },
            { "KWARA", new List<string> { "ASA", "BARUTEN", "EDU", "EKITI", "IFELODUN", "ILORIN EAST", "ILORIN SOUTH", "ILORIN WEST", "IREPODUN", "ISIN", "KAIAMA", "MORO", "OFFA", "OKE ERO", "OYUN", "PATEGI" } },
            { "LAGOS", new List<string> { "AGEGE", "AJEROMI-IFELODUN", "ALIMOSHO", "AMUWO-ODOFIN", "APAPA", "BADAGRY", "EPE", "ETI OSA", "IBEJU-LEKKI", "IFAKO-IJAIYE", "IKEJA", "IKORODU", "KOSOFE", "LAGOS ISLAND", "LAGOS MAINLAND", "MUSHIN", "OJO", "OSHODI-ISOLO", "SHOMOLU", "SURULERE" } },
            { "NASARAWA", new List<string> { "AKWANGA", "AWE", "DOMA", "KARU", "KEANA", "KEFFI", "KOKONA", "LAFIA", "NASARAWA", "NASARAWA EGON", "OBI", "TOTO", "WAMBA" } },
            { "NIGER", new List<string> { "AGAIE", "AGWARA", "BIDA", "BORGU", "BOSSO", "CHANCHAGA", "EDATI", "GBAKO", "GURARA", "KATCHA", "KONTAGORA", "LAPAI", "LAVUN", "MAGAMA", "MARIGA", "MASHEGU", "MOKWA", "MUYA", "PAIKORO", "RAFI", "RIJAU", "SHIRORO", "SULEJA", "TAFA", "WUSHISHI" } },
            { "OGUN", new List<string> { "ABEOKUTA NORTH", "ABEOKUTA SOUTH", "ADO-ODO/OTA", "EWEKORO", "IFO", "IJEBU EAST", "IJEBU NORTH", "IJEBU NORTH EAST", "IJEBU ODE", "IKENNE", "IMEKO AFON", "IPOKIA", "OBAFEMI OWODE", "ODEDA", "ODOGBOLU", "OGUN WATERSIDE", "REMO NORTH", "SHAGAMU", "YEWA NORTH", "YEWA SOUTH" } },
            { "ONDO", new List<string> { "AKOKO NORTH-EAST", "AKOKO NORTH-WEST", "AKOKO SOUTH-EAST", "AKOKO SOUTH-WEST", "AKURE NORTH", "AKURE SOUTH", "ESE ODO", "IDANRE", "IFEDORE", "ILAJE", "ILE OLUJI/OKEIGBO", "IRELE", "ODIGBO", "OKITIPUPA", "ONDO EAST", "ONDO WEST", "OSE", "OWO" } },
            { "OSUN", new List<string> { "AIYEDAADE", "AIYEDIRE", "ATAKUNMOSA EAST", "ATAKUNMOSA WEST", "BOLUWADURO", "BORIPE", "EDE NORTH", "EDE SOUTH", "EGBEDORE", "EJIGBO", "IFE CENTRAL", "IFE EAST", "IFE NORTH", "IFE SOUTH", "IFEDAYO", "IFEDODUN", "ILA", "ILESA EAST", "ILESA WEST", "IREPODUN", "IREWOLE", "ISOKAN", "IWO", "OBOKUN", "ODO OTIN", "OLA OLUWA", "OLORUNDA", "ORIADE", "OROLU", "OSOGBO" } },
            { "OYO", new List<string> { "AFIJIO", "AKINYELE", "ATIBA", "ATISBO", "EGBEDA", "IBADAN NORTH", "IBADAN NORTH-EAST", "IBADAN NORTH-WEST", "IBADAN SOUTH-EAST", "IBADAN SOUTH-WEST", "IBARAPA CENTRAL", "IBARAPA EAST", "IBARAPA NORTH", "IDO", "IREPO", "ISEYIN", "ITESIWAJU", "IWAJOWA", "KAJOLA", "LAGELU", "OGBOMOSHO NORTH", "OGBOMOSHO SOUTH", "OGO OLUWA", "OLORUNSOGO", "OLUYOLE", "ONA ARA", "ORELOPE", "ORI IRE", "OYO EAST", "OYO WEST", "SAKI EAST", "SAKI WEST", "SURULERE" } },
            { "PLATEAU", new List<string> { "BARKIN LADI", "BASSA", "BOKKOS", "JOS EAST", "JOS NORTH", "JOS SOUTH", "KANAM", "KANKE", "LANGTANG NORTH", "LANGTANG SOUTH", "MANGU", "MIKANG", "PANKSHIN", "QUA'AN PAN", "RIYOM", "SHENDAM", "WASE" } },
            { "RIVERS", new List<string> { "ABUA/ODUAL", "AHOADA EAST", "AHOADA WEST", "AKUKU-TORU", "ANDONI", "ASARI-TORU", "BONNY", "DEGEMA", "ELEME", "EMOHUA", "ETCHE", "GOKANA", "IKWERRE", "KHANA", "OBIO/AKPOR", "OGBA/EGBEMA/NDONI", "OGU/BOLO", "OKRIKA", "OMUMA", "OPOBO/NKORO", "OYIGBO", "PORT HARCOURT", "TAI" } },
            { "SOKOTO", new List<string> { "BINJI", "BODINGA", "DANGE SHUNI", "GADA", "GORONYO", "GUDU", "GWADABAWA", "ILLELA", "ISA", "KEBBE", "KWARE", "RABA", "SABON BIRNI", "SHAGARI", "SILAME", "SOKOTO NORTH", "SOKOTO SOUTH", "TAMBUWAL", "TANGAZA", "TURETA", "WAMAKKO", "WURNO", "YABO" } },
            { "TARABA", new List<string> { "ARDO-KOLA", "BALI", "DONGA", "GASHAKA", "GASSOL", "IBI", "JALINGO", "KARIM-LAMIDO", "KURMI", "LAU", "SADAU", "SARA DAUNA", "TAKUM", "UPPA", "Ussa", "WUKARI", "YORRO", "ZING" } },
            { "YOBE", new List<string> { "BADE", "BURSARI", "DAMATURU", "FIKA", "FUNE", "GEIDAM", "GUJBA", "GULANI", "JAKUSKO", "KARASUWA", "MACHINA", "NANGERE", "NGURU", "POTISKUM", "TARMUWA", "YUNUSARI", "YUSUFARI" } },
            { "ZAMFARA", new List<string> { "ANKA", "BAKURA", "BIRNIN MAGAJI/KIYAW", "BUKKUYUM", "BUNGUDU", "GUMMI", "GUSAU", "KAURA NAMODA", "MARADUN", "MARU", "SHINKAFI", "TALATA MAFARA", "TSAFE", "ZURMI" } }
        };
    }
}