using Microsoft.AspNetCore.Mvc;

namespace NTS.Controllers;

[ApiController]
[Route("[controller]")]
public class NTSCotroller : ControllerBase
{


    private readonly ILogger<NTSCotroller> _logger;

    public NTSCotroller(ILogger<NTSCotroller> logger)
    {
        _logger = logger;
    }



    [HttpGet(Name = "NTS")]
    public string NTS(long numero)
    {
        return NumToStr(numero);
    }


    private string NumToStr(long numero)
    {
        if (numero == 0) return "cero";

        if (numero <= 15)
        {
            return NumToStrUnidades(numero);
        }
        if (numero <= 100 && numero >= 16)
        {
            return NumToStrDecenas(numero);
        }
        if (numero <= 1000 && numero >= 101)
        {
            return NumToStrCentenas(numero);
        }
        if (numero < 1000000 && numero >= 1001)
        {
            return NumToStrMiles(numero);
        }
        if (numero >= 1000000 && numero < 1000000000000)
        {
            return NumToStrMillones(numero);
        }
        if (numero == 1000000000000)
        {
            return "un billon";
        }
        if (numero > 1000000000000)
        {
            return "no se contar mas de un billon";
        }
        else return "Error";
    } 

    private string NumToStrUnidades(long numero)
    {
        var unidades = new[] {"cero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez", "once", "doce", "trece", "catorce", "quince"};
        if (numero < 16)
    {
        return unidades[numero];
    }

    else return "error";
    }

    private string NumToStrDecenas(long numero)
    {
        var decenas = new[] {"cero", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa", "cien"};
        if (numero <= 100 && numero > 15)
        {
            if ((numero % 10) == 0 && numero != 20 && numero != 30)
                return decenas[numero/10];
            else
                if (numero <= 20 && numero >= 16)
                {
                    return NumToStrDieci(numero);
                }
                if (numero <= 30 && numero >= 21)
                {
                    return NumToStrVeinti(numero);
                }
                else
                    return decenas[numero / 10] + " y " + NumToStr(numero % 10);
        }
        else return "error";
    }

    private string NumToStrDieci(long numero)
    {
        if (numero < 20 && numero > 15)
        {
            numero = numero % 10;
            return "dieci" + NumToStr(numero);
        }
        if (numero == 20)
        {
            return "veinte";
        }
        else return "error";
    }

    private string NumToStrVeinti(long numero)
    {
        if (numero < 30 && numero > 20)
        {
            numero = numero % 10;
            return "veinti" + NumToStr(numero);
        }
        if (numero == 30)
        {
            return "treinta";
        }
        else return "error";
    }

    private string NumToStrCentenas(long numero)
    {
        var centenas = new[] {"cero", "ciento", "docientos", "trescientos", "cuatrocientos", "quinientos", "sesiscientos", "setecientos", "ochocientos", "novecientos", "mil"};
        if (numero <= 1000 && numero > 100)
        {
            if ((numero % 100) == 0)
                return centenas[numero / 100];
            else 
                return centenas[numero / 100] + " " + NumToStr(numero % 100);
        }
        else return "error";
    }

    private string NumToStrMiles(long numero)
    {
        if (numero > 1000)
        {
            if ((numero % 1000) == 0)
                if (numero == 1000)
                    return "mil";
                else
                    return NumToStr(numero / 1000) + " mil";
            else 
                if (Math.Truncate((decimal)numero / 1000) == 1)
                    return "mil " + NumToStr(numero % 1000);
                else 
                    return NumToStr(numero / 1000) + "mil " + NumToStr(numero % 1000);
        }
        else return "error";
    }

    private string NumToStrMillones(long numero)
    {
        if (numero >= 1000000)
        {
            if ((numero % 1000000) == 0)
                if (numero == 1000000)
                    return "un millon";
                else
                    return NumToStr(numero / 1000000) + " millones";
            else 
                if (Math.Truncate((decimal)numero / 1000000) == 1)
                    return "un millon " + NumToStr(numero % 1000);
                else 
                    return NumToStr(numero / 1000000) + " millones " + NumToStr(numero % 1000000);
        }
        else return "error";
    }
}
