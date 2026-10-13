using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;


/// <summary>
/// Descripción breve de formatoBuro
/// </summary>
public class formatoBuro
{
    public DataSet dsRepBuro = new dsBuro();
    private string usuarioBuro = string.Empty;
    private string passBuro = string.Empty;

	public formatoBuro()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
        usuarioBuro = ConfigurationManager.AppSettings.Get("usuarioBuro");
        passBuro = ConfigurationManager.AppSettings.Get("passBuro");
	}

        public string generaConsulta(DataSet ds)
        {
            long longTrans = 0;
            string msgEnc = string.Empty;
            string msgNombre = string.Empty;
            string msgDir = string.Empty;
            string msgFin = string.Empty;

            if (ds != null)
            {
                msgEnc = encabezado(ds);
                longTrans += msgEnc.Length;
                msgNombre = nombre(ds);
                longTrans += msgNombre.Length;
                msgDir = direccion(ds);
                longTrans += msgDir.Length;
            }
            longTrans += 15;
            msgFin = fin(longTrans);

            return msgEnc + msgNombre + msgDir + msgFin;
        }

        public string encabezado(DataSet ds)
        {
            string cadEncabezado = string.Empty;
            string version = "11";
            string refOpe = "                         "; // LONGITUD DE 25 CARACTERES
            string prod = "001";
            string cvePais = "MX";
            string idBuro = "0000";
            string cveUsuario = usuarioBuro;           //LONGITUD DE 10 CARACTERES
            string pass = passBuro;                   //LONGITUD DE 8 CARACTERES
            string tipoCons = "I";
            string tipoNeg = "MI";                      //LONGITUD DE 2 CARACTERES (TIPO DE NEGOCIO MICROFINANCIERA) 
            string cveMoneda = "MX";
            string cadImporte = string.Empty;           //LONGITUD DE 9 CARACTERES 
            string idioma = "SP";
            string tipoSalida = "01";                   //LONGITUD DE 2 CARACTERES
            string tamBloque = " ";                     //LONGITUD DE 1 CARACTER (LLENAR CON VACIOS)
            string idImpresora = "    ";                //LONGITUD DE 4 CARACTERES (LLENAR CON VACIOS) 
            string usoFuturo = "0000000";

            int cont = 0;
            long importe = 0;

            //RECIBE LA INFORMACION DEL IMPORTE DEL CREDITO
            if (ds.Tables[0].Rows[0]["CANTSOLIC"].ToString() != "")
                importe = Convert.ToInt64(ds.Tables[0].Rows[0]["CANTSOLIC"].ToString());
            else
                importe = 0;

            cont = importe.ToString().Length;
            cadImporte = importe.ToString();

            //RELLENA CON CEROS LA PARTE IZQUIERDA DE LA CADENA DE IMPORTE HASTA COMPLETAR LA LONGITUD SOLICITADA
            cadImporte = complementaCero(cadImporte, cont, 9);

            cadEncabezado = "INTL" + version + refOpe + prod + cvePais + idBuro + cveUsuario +
                            pass + tipoCons + tipoNeg + cveMoneda + cadImporte + idioma + tipoSalida + tamBloque +
                            idImpresora + usoFuturo;

            return cadEncabezado;
        }

        public string nombre(DataSet ds)
        {
            string cadNombre = string.Empty;
            string aPaterno = string.Empty;
            string aMaterno = string.Empty;
            string aOpcional = string.Empty;
            string pNombre = string.Empty;
            string sNombre = string.Empty;
            string fecNac = string.Empty;
            string rfc = string.Empty;
            string prefPers = string.Empty;     //OPCIONAL CON 4 CARACTERES
            string subfijo = string.Empty;      //OPCIONAL CON 4 CARACTERES
            string nac = string.Empty;          //OPCIONAL CON 2 CARACTERES 
            string resid = string.Empty;        //OPCIONAL CON 1 CARACTER
            string licencia = string.Empty;     //OPCIONAL CON 20 CARACTERES
            string edoCivil = string.Empty;     //OPCIONAL CON 1 CARACTER
            string sexo = string.Empty;         //OPCIONAL CON 1 CARACTER
            string cedula = string.Empty;       //OPCIONAL CON 20 CARACTERES
            string ife = string.Empty;          //OPCIONAL CON 20 CARACTERES
            string impOtroPais = string.Empty;  //OPCIONAL CON 20 CARACTERES
            string otroPais = string.Empty;     //OPCIONAL CON 2 CARACTERES
            string depend = string.Empty;       //OPCIONAL CON 2 CARACTERES
            string edadDepend = string.Empty;   //OPCIONAL CON 30 CARACTERES
            
            try
            {
                aPaterno = ds.Tables[0].Rows[0]["PRIMAPE"].ToString();
                aPaterno = "PN" + formateaCadena(aPaterno, 2);

                if (ds.Tables[0].Rows[0]["SEGAPE"].ToString() != "")
                    aMaterno = ds.Tables[0].Rows[0]["SEGAPE"].ToString();
                else
                    aMaterno = "NO PROPORCIONADO";
                aMaterno = "00" + formateaCadena(aMaterno, 2);

                //FORMATEA APELLIDO OPCIONAL (SE OMITE DATO POR AUSENCIA)
                //int lonAOpcional = aOpcional.Length;
                //aOpcional = "01" + formateaCadena(aOpcional, 2);

                pNombre = ds.Tables[0].Rows[0]["NOMBRE1"].ToString();
                pNombre = "02" + formateaCadena(pNombre, 2);

                if (ds.Tables[0].Rows[0]["NOMBRE2"].ToString() != "")
                {
                    sNombre = ds.Tables[0].Rows[0]["NOMBRE2"].ToString();
                    sNombre = "03" + formateaCadena(sNombre, 2);
                }

                if (ds.Tables[0].Rows[0]["NACIMIENTO"].ToString() != "")
                {
                    fecNac = ds.Tables[0].Rows[0]["NACIMIENTO"].ToString();
                    fecNac = "04" + formateaCadena(formateaFecha(fecNac),2);
                }

                if (ds.Tables[0].Rows[0]["RFC"].ToString() != "")
                {
                    rfc = ds.Tables[0].Rows[0]["RFC"].ToString();
                    rfc = rfc.Trim();
                    rfc = rfc.Replace("-", "");
                    rfc = rfc.Substring(0,10);
                    rfc = "05" + formateaCadena(rfc, 2);
                }

                //FORMATEA PREFIJO PERSONAL (SE OMITE DATO POR AUSENCIA)
                //prefPers = "06" + formateaCadena(prefPers, 2);

                //FORMATEA SUFIJO PERSONAL (SE OMITE DATO POR AUSENCIA)
                //subFijo = "07" + formateaCadena(subFijo, 2);

                if (ds.Tables[0].Rows[0]["NACIONALIDAD"].ToString() != "")
                {
                    nac = ds.Tables[0].Rows[0]["NACIONALIDAD"].ToString();
                    nac = "08" + formateaCadena(nac, 2);
                }

                //FORMATEA RESIDENCIA (SE OMITE DATO POR AUSENCIA)
                //resid = "09" + formateaCadena(resid, 2);

                //FORMATEA LICENCIA DE CONDUCIR (SE OMITE DATO POR AUSENCIA)
                //resid = "10" + formateaCadena(licencia, 2);

                if (ds.Tables[0].Rows[0]["EDOCIVIL"].ToString() != "")
                {
                    edoCivil = ds.Tables[0].Rows[0]["EDOCIVIL"].ToString();
                    edoCivil = "11" + formateaCadena(edoCivil, 2);
                }

                if (ds.Tables[0].Rows[0]["SEXO"].ToString() != "")
                {
                    sexo = ds.Tables[0].Rows[0]["SEXO"].ToString();
                    sexo = "12" + formateaCadena(sexo, 2);
                }

                //FORMATEA CEDULA PROFESIONAL (SE OMITE DATO POR AUSENCIA)
                //cedula = "13" + formateaCadena(cedula, 2);

                if (ds.Tables[0].Rows[0]["IFE"].ToString() != "")
                {
                    ife = ds.Tables[0].Rows[0]["IFE"].ToString();
                    ife = "14" + formateaCadena(ife, 2);
                }

                //FORMATEA CLAVE DE IMPUESTOS DE OTRO PAIS (SE OMITE DATO POR AUSENCIA)
                //impOtroPais = "15" + formateaCadena(impOtroPais, 2);

                //FORMATEA CLAVE OTRO PAIS (SE OMITE DATO POR AUSENCIA)
                //otroPais = "16" + formateaCadena(otroPais, 2);

                if (ds.Tables[0].Rows[0]["NODEPEND"].ToString() != "")
                {
                    depend = ds.Tables[0].Rows[0]["NODEPEND"].ToString();
                    depend = "17" + formateaCadena(depend, 2);
                }

                //FORMATEA EDAD DE DEPENDIENTES (SE OMITE DATO POR AUSENCIA)
                //edadDepend = "18" + formateaCadena(edadDepend, 2);

                cadNombre = aPaterno + aMaterno + aOpcional + pNombre + sNombre + fecNac + rfc + prefPers + subfijo +
                            nac + resid + licencia + edoCivil + sexo + cedula + ife + impOtroPais + otroPais +
                            depend + edadDepend;

                return cadNombre;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string direccion(DataSet ds)
        {
            string cadDireccion = string.Empty;
            string dir1 = string.Empty;             //40 CARACTERES
            string dir2 = string.Empty;             //OPCIONAL CON 40 CARACTERES
            string colonia = string.Empty;          //OPCIONAL CON 40 CARACTERES
            string municipio = string.Empty;       //40 CARACTERES
            string ciudad = string.Empty;           //40 CARACTERES
            string estado = string.Empty;           //4 CARACTERES
            string codPostal = string.Empty;        //5 CARACTERES
            string fecResidencia = string.Empty;    //OPCIONAL CON 8 CARACTERES
            string telefono = string.Empty;         //OPCIONAL CON 11 CARACTERES
            string extension = string.Empty;        //OPCIONAL CON 8 CARACTERES
            string fax = string.Empty;              //OPCIONAL CON 11 CARACTERES
            string tipoDom = string.Empty;          //OPCIONAL CON 1 CARACTER
            string indEspDom = string.Empty;        //OPCIONAL CON 1 CARACTER

            dir1 = ds.Tables[0].Rows[0]["CALLE"].ToString();
            dir1 = "PA" + formateaCadena(dir1, 2);

            //FORMATEA DIRECCION 2 (SE OMITE DATO POR AUSENCIA)
            //dir2 = "00" + formateaCadena(dir2, 2);

            if (ds.Tables[0].Rows[0]["COL"].ToString() != "")
            {
                colonia = ds.Tables[0].Rows[0]["COL"].ToString();
                colonia = "01" + formateaCadena(colonia, 2);
            }

            if (ds.Tables[0].Rows[0]["MUNIC"].ToString() != "")
            {
                municipio = ds.Tables[0].Rows[0]["MUNIC"].ToString();
                municipio = "02" + formateaCadena(municipio, 2);
            }

            if (ds.Tables[0].Rows[0]["LOC"].ToString() != "")
            {
                ciudad = ds.Tables[0].Rows[0]["LOC"].ToString();
                ciudad = "03" + formateaCadena(ciudad, 2);
            }

            estado = ds.Tables[0].Rows[0]["ENTFEDBC"].ToString();
            estado = "04" + formateaCadena(estado, 2);

            if (ds.Tables[0].Rows[0]["CDGPOSTAL"].ToString() != "")
            {
                codPostal = ds.Tables[0].Rows[0]["CDGPOSTAL"].ToString();
                codPostal = "05" + formateaCadena(codPostal, 2);
            }

            //FORMATEA FECHA DE RESIDENCIA (SE OMITE DATO POR AUSENCIA)
            //fecResidencia = "06" + formateaCadena(fecResidencia, 2);

            if (ds.Tables[0].Rows[0]["TELEFONO"].ToString() != "")
            {
                telefono = ds.Tables[0].Rows[0]["TELEFONO"].ToString();
                telefono = "07" + formateaCadena(telefono, 2);
            }

            //FORMATEA EXTENSION (SE OMITE DATO POR AUSENCIA)
            //extension = "08" + formateaCadena(extension, 2);

            //FORMATEA FAX (SE OMITE DATO POR AUSENCIA)
            //fax = "09" + formateaCadena(fax, 2);

            //FORMATEA TIPO DE DOMICILIO (SE OMITE DATO POR AUSENCIA)
            //tipoDom = "10" + formateaCadena(tipoDom, 2);

            //FORMATEA INDICADOR ESPECIAL DE DOMICILIO (SE OMITE DATO POR AUSENCIA)
            //indEspDom = "11" + formateaCadena(indEspDom, 2);

            cadDireccion = dir1 + dir2 + colonia + municipio + ciudad + estado + codPostal + fecResidencia +
                           telefono + extension + fax + tipoDom + indEspDom;

            return cadDireccion;
        }

        public string empleo(DataSet ds)
        {
            string cadEmpleo = string.Empty;
            string empresa = string.Empty;          //REVISAR CONDICIONES EN MANUAL 40 CARACTERES
            string dirLinea1 = string.Empty;        //OPCIONAL CON 40 CARACTERES
            string dirLinea2 = string.Empty;        //OPCIONAL CON 40 CARACTERES
            string colonia = string.Empty;          //OPCIONAL CON 40 CARACTERES
            string municipio = string.Empty;        //OPCIONAL CON 40 CARACTERES
            string ciudad = string.Empty;           //OPCIONAL CON 40 CARACTERES
            string estado = string.Empty;           //OPCIONAL CON 4 CARACTERES
            string codPostal = string.Empty;        //OPCIONAL CON 5 CARACTERES
            string telefono = string.Empty;         //OPCIONAL CON 11 CARACTERES
            string extension = string.Empty;        //OPCIONAL CON 8 CARACTERES
            string fax = string.Empty;              //OPCIONAL CON 11 CARACTERES
            string cargo = string.Empty;            //OPCIONAL DE 30 CARACTERES
            string fecContratacion = string.Empty;  //OPCIONAL CON 8 CARACTERES
            string monedaSalario = string.Empty;    //OPCIONAL CON 2 CARACTERES
            string salario = string.Empty;          //OPCIONAL CON 9 CARACTERES
            string baseSalarial = string.Empty;     //OPCIONAL CON 1 CARACTER
            string numeroEmp = string.Empty;        //OPCIONAL CON 15 CARACTERES
            string fecUltDiaEmp = string.Empty;     //OPCIONAL CON 8 CARACTERES

            cadEmpleo = empresa + dirLinea1;

            return cadEmpleo;
        }

        public string cuentas(DataSet ds)
        {
            string cadCuentas = string.Empty;
            string numCuenta = string.Empty;        //OPCIONAL CON 25 CARACTERES
            string cveOtorgante = string.Empty;     //OPCIONAL CON 10 CARACTERES
            string nomOtorgante = string.Empty;     //OPCIONAL CON 16 CARACTERES

            return cadCuentas;
        }

        public string autenticacion(DataSet ds)
        {
            string cadAut = string.Empty;
            string tipoRep = string.Empty;          //3 CARACTERES
            string tipoSalida = string.Empty;       //1 CARACTER
            string refOperador = string.Empty;      //25 CARACTERES
            string tarjCred = string.Empty;         //1 CARACTER
            string ultDigitos = string.Empty;       //OPCIONAL CON 4 CARACTERES
            string credHip = string.Empty;          //1 CARACTER
            string credAtut = string.Empty;         //1 CARACTER

            return cadAut;
        }

        public string fin(long longTrans)
        {
            string cadFin = string.Empty;
            string trans = string.Empty;
            string marcaFin = string.Empty;

            trans = "ES05" + complementaCero(longTrans.ToString(), longTrans.ToString().Length, 5);

            marcaFin = "0002**";

            cadFin = trans + marcaFin; 

            return cadFin;
        }

        //FUNCION QUE AGREGA EL CONTEO DE CARACTERES AL INICIO DE LA CADENA
        public string complementaCero(string cadena, int actual, int maxDigito)
        {
            int i;
            for (i = 0; i < (maxDigito - actual); i++)
            {
                cadena = "0" + cadena;
            }
            return cadena;
        }

        public string formateaCadena(string cadena, int maxDigito)
        {
            int longitud = cadena.Length;
            cadena = cadena.ToUpper();
            cadena = cadena.Replace("Ñ", "N");
            cadena = cadena.Replace("ñ", "n");
            cadena = cadena.Replace("-", "");
            cadena = cadena.Replace(",", "");
            return complementaCero(longitud.ToString(), longitud.ToString().Length, maxDigito) + cadena;
        }

        public string formateaFecha(string fecha)
        {
            return fecha.Replace("/", "");
        }

        public DataSet interpretaRespuesta(string respuesta)
        {
            if (respuesta.Substring(0, 4) != "ERRR")
            {
                string cadena = respuesta.Substring(49);
                string seg = string.Empty;
                int i = 0;
                int cont = cadena.Length;
                do
                {
                    seg = cadena.Substring(i, 2);
                    switch (seg)
                    {
                        case "PN":
                            segmentoNombre(cadena, ref i);
                            break;
                        case "PA":
                            segmentoDireccion(cadena, ref i);
                            break;
                        case "PE":
                            segmentoEmpleo(cadena, ref i);
                            break;
                        case "TL":
                            segmentoCuenta(cadena, ref i);
                            break;
                        case "IQ":
                            segmentoConsulta(cadena, ref i);
                            break;
                        case "RS":
                            segmentoResumen(cadena, ref i);
                            break;
                        case "CR":
                            segmentoDeclaracion(cadena, ref i, cont);
                            break;
                        case "SC":
                            segmentoScore(cadena, ref i);
                            break;
                        case "ES":
                            segmentoFin(cadena, ref i);
                            break;
                    }
                } while (i < cont);
                return dsRepBuro;
            }
            else
            {
                string campo = string.Empty;
                string descError = string.Empty;
                string info = string.Empty;
                string ultProc = string.Empty;
                string cadena = respuesta.Substring(37);
                string seg = string.Empty;
                int i = 0;
                int longitud;
                int cont = cadena.Length;
                bool band = true;

                string[] Arr;

                string inicio = "ES";
                Arr = inicio.Split(',');

                seg = cadena.Substring(i, 2);
                switch (seg){
                    case "PN":
                        descError = "Error en la informacion general del Cliente.\n\n";    
                        break;
                    case "PA":
                        descError = "Error en la información de dirección del Cliente.\n\n";
                        break;
                    case "TL":
                        descError = "Error en la información de cuentas del Cliente.\n\n";
                        break;
                    }
                    i += 2;
                    ultProc = cadena.Substring(i, 4);
                    i += 4;
                    descError += "Último registro procesado: " + ultProc + ".\n\n";

                    if (buscaSegmento(cadena.Substring(i, 2), Arr))
                    {
                        descError += "Favor de Verificar la siguiente información:\n";
                        do
                        {
                            campo = cadena.Substring(i, 2);
                            i += 2;
                            longitud = Convert.ToInt32(cadena.Substring(i, 2));
                            i += 2;
                            info = cadena.Substring(i, longitud);
                            descError += info + "\n";
                            i += longitud;
                            band = buscaSegmento(cadena.Substring(i, 2), Arr);
                        } while (band);
                    }
                throw new Exception(descError);
            }
        }

        public void segmentoNombre(string cadena, ref int i)
        {
            string aPaterno = string.Empty;
            string aMaterno = string.Empty;
            string aOpcional = string.Empty;
            string pNombre = string.Empty;
            string sNombre = string.Empty;
            string fecNac = string.Empty;
            string rfc = string.Empty;
            string prefPers = string.Empty;     //OPCIONAL CON 4 CARACTERES
            string subfijo = string.Empty;      //OPCIONAL CON 4 CARACTERES
            string nac = string.Empty;          //OPCIONAL CON 2 CARACTERES 
            string resid = string.Empty;        //OPCIONAL CON 1 CARACTER
            string licencia = string.Empty;     //OPCIONAL CON 20 CARACTERES
            string edoCivil = string.Empty;     //OPCIONAL CON 1 CARACTER
            string sexo = string.Empty;         //OPCIONAL CON 1 CARACTER
            string cedula = string.Empty;       //OPCIONAL CON 20 CARACTERES
            string ife = string.Empty;          //OPCIONAL CON 20 CARACTERES
            string impOtroPais = string.Empty;  //OPCIONAL CON 20 CARACTERES
            string otroPais = string.Empty;     //OPCIONAL CON 2 CARACTERES
            string depend = string.Empty;       //OPCIONAL CON 2 CARACTERES
            string edadDepend = string.Empty;   //OPCIONAL CON 30 CARACTERES
            string fecInfoDepend = string.Empty;//OPCIONAL CON 8 CARACTERES
            string fecDefunc = string.Empty;    //OPCIONAL CON 8 CARACTERES

            string[] Arr;

            string inicio = "PA,PE,TL,IQ,RS,CR,SC,ES";
            Arr = inicio.Split(',');

            dsBuro.dtNombreDataTable dtNombre = new dsBuro.dtNombreDataTable();
            DataTable dtRepNombre = (DataTable)dtNombre;
            DataRow drNombre = dtRepNombre.NewRow(); 

            string seg = string.Empty;
            int longitud;
            Boolean band = true;
            do
            {
                seg = cadena.Substring(i, 2);
                i += 2;
                longitud = Convert.ToInt32(cadena.Substring(i, 2));
                i += 2;
                switch (seg)
                {
                    case "PN":
                        aPaterno = cadena.Substring(i, longitud);
                        drNombre["APATERNO"] = aPaterno; 
                        //MessageBox.Show(aPaterno);
                        break;
                    case "00":
                        aMaterno = cadena.Substring(i, longitud);
                        drNombre["AMATERNO"] = aMaterno;
                        //MessageBox.Show(aMaterno);
                        break;
                    case "01":
                        aOpcional = cadena.Substring(i, longitud);
                        drNombre["AOPCIONAL"] = aOpcional;
                        //MessageBox.Show(aOpcional);
                        break;
                    case "02":
                        pNombre = cadena.Substring(i, longitud);
                        drNombre["PNOMBRE"] = pNombre;
                        //MessageBox.Show(pNombre);
                        break;
                    case "03":
                        sNombre = cadena.Substring(i, longitud);
                        drNombre["SNOMBRE"] = sNombre;
                        //MessageBox.Show(sNombre);
                        break;
                    case "04":
                        fecNac = cadena.Substring(i, longitud);
                        drNombre["FECNAC"] = fecNac;
                        //MessageBox.Show(fecNac);
                        break;
                    case "05":
                        rfc = cadena.Substring(i, longitud);
                        drNombre["RFC"] = rfc;
                        //MessageBox.Show(rfc);
                        break;
                    case "06":
                        prefPers = cadena.Substring(i, longitud);
                        drNombre["PREFPERS"] = prefPers;
                        //MessageBox.Show(prefPers);
                        break;
                    case "07":
                        subfijo = cadena.Substring(i, longitud);
                        drNombre["SUBFIJO"] = subfijo;
                        //MessageBox.Show(subfijo);
                        break;
                    case "08":
                        nac = cadena.Substring(i, longitud);
                        drNombre["NAC"] = nac;
                        //MessageBox.Show(nac);
                        break;
                    case "09":
                        resid = cadena.Substring(i, longitud);
                        drNombre["RESID"] = resid;
                        //MessageBox.Show(resid);
                        break;
                    case "10":
                        licencia = cadena.Substring(i, longitud);
                        drNombre["LICENCIA"] = licencia;
                        //MessageBox.Show(licencia);
                        break;
                    case "11":
                        edoCivil = cadena.Substring(i, longitud);
                        drNombre["EDOCIVIL"] = edoCivil;
                        //MessageBox.Show(edoCivil);
                        break;
                    case "12":
                        sexo = cadena.Substring(i, longitud);
                        drNombre["SEXO"] = sexo;
                        //MessageBox.Show(sexo);
                        break;
                    case "13":
                        cedula = cadena.Substring(i, longitud);
                        drNombre["CEDULA"] = cedula;
                        //MessageBox.Show(cedula);
                        break;
                    case "14":
                        ife = cadena.Substring(i, longitud);
                        drNombre["IFE"] = ife;
                        //MessageBox.Show(ife);
                        break;
                    case "15":
                        impOtroPais = cadena.Substring(i, longitud);
                        drNombre["IMPOTROPAIS"] = impOtroPais;
                        //MessageBox.Show(impOtroPais);
                        break;
                    case "16":
                        otroPais = cadena.Substring(i, longitud);
                        //MessageBox.Show(otroPais);
                        break;
                    case "17":
                        depend = cadena.Substring(i, longitud);
                        drNombre["DEPEND"] = depend;
                        //MessageBox.Show(depend);
                        break;
                    case "18":
                        edadDepend = cadena.Substring(i, longitud);
                        drNombre["EDADDEPEND"] = edadDepend;
                        //MessageBox.Show(edadDepend);
                        break;
                    case "19":
                        fecInfoDepend = cadena.Substring(i, longitud);
                        drNombre["FECINFODEPEND"] = fecInfoDepend;
                        //MessageBox.Show(fecInfoDepend);
                        break;
                    case "20":
                        fecDefunc = cadena.Substring(i, longitud);
                        drNombre["FECDEFUNC"] = fecDefunc;
                        //MessageBox.Show(fecDefunc);
                        break;
                }
                i += longitud;
                band = buscaSegmento(cadena.Substring(i, 2), Arr);

            } while (band);
            dtRepNombre.Rows.Add(drNombre);
            dsRepBuro.Tables["dtNombre"].ImportRow(drNombre);
        }

        public void segmentoDireccion(string cadena, ref int i)
        {
            string dir1 = string.Empty;             //40 CARACTERES
            string dir2 = string.Empty;             //OPCIONAL CON 40 CARACTERES
            string colonia = string.Empty;          //OPCIONAL CON 40 CARACTERES
            string municipio = string.Empty;       //40 CARACTERES
            string ciudad = string.Empty;           //40 CARACTERES
            string estado = string.Empty;           //4 CARACTERES
            string codPostal = string.Empty;        //5 CARACTERES
            string fecResidencia = string.Empty;    //OPCIONAL CON 8 CARACTERES
            string telefono = string.Empty;         //OPCIONAL CON 11 CARACTERES
            string extension = string.Empty;        //OPCIONAL CON 8 CARACTERES
            string fax = string.Empty;              //OPCIONAL CON 11 CARACTERES
            string tipoDom = string.Empty;          //OPCIONAL CON 1 CARACTER
            string indEspDom = string.Empty;        //OPCIONAL CON 1 CARACTER
            string fecDom = string.Empty;            //OPCIONAL CON 8 CARACTERES
            
            string[] Arr;

            string inicio = "PA,PE,TL,IQ,RS,CR,SC,ES";
            Arr = inicio.Split(',');

            dsBuro.dtDireccionDataTable dtDireccion = new dsBuro.dtDireccionDataTable();
            DataTable dtRepDireccion = (DataTable)dtDireccion;
            DataRow drDireccion = dtRepDireccion.NewRow();

            string seg = string.Empty;
            int longitud;
            Boolean band = true;
            do
            {
                seg = cadena.Substring(i, 2);
                i += 2;
                longitud = Convert.ToInt32(cadena.Substring(i, 2));
                i += 2;
                switch (seg)
                {
                    case "PA":
                        dir1 = cadena.Substring(i, longitud);
                        drDireccion["DIR1"] = dir1;
                        //MessageBox.Show(dir1);
                        break;
                    case "00":
                        dir2 = cadena.Substring(i, longitud);
                        drDireccion["DIR2"] = dir2;
                        //MessageBox.Show(dir2);
                        break;
                    case "01":
                        colonia = cadena.Substring(i, longitud);
                        drDireccion["COLONIA"] = colonia;
                        //MessageBox.Show(colonia);
                        break;
                    case "02":
                        municipio = cadena.Substring(i, longitud);
                        drDireccion["MUNICIPIO"] = municipio;
                        //MessageBox.Show(municipio);
                        break;
                    case "03":
                        ciudad = cadena.Substring(i, longitud);
                        drDireccion["CIUDAD"] = ciudad;
                        //MessageBox.Show(ciudad);
                        break;
                    case "04":
                        estado = cadena.Substring(i, longitud);
                        drDireccion["ESTADO"] = estado;
                        //MessageBox.Show(estado);
                        break;
                    case "05":
                        codPostal = cadena.Substring(i, longitud);
                        drDireccion["CODPOSTAL"] = codPostal;
                        //MessageBox.Show(codPostal);
                        break;
                    case "06":
                        fecResidencia = cadena.Substring(i, longitud);
                        drDireccion["FECRESIDENCIA"] = fecResidencia;
                        //MessageBox.Show(fecResidencia);
                        break;
                    case "07":
                        telefono = cadena.Substring(i, longitud);
                        drDireccion["TELEFONO"] = telefono;
                        //MessageBox.Show(telefono);
                        break;
                    case "08":
                        extension = cadena.Substring(i, longitud);
                        drDireccion["EXTENSION"] = extension;
                        //MessageBox.Show(extension);
                        break;
                    case "09":
                        fax = cadena.Substring(i, longitud);
                        drDireccion["FAX"] = fax;
                        //MessageBox.Show(fax);
                        break;
                    case "10":
                        tipoDom = cadena.Substring(i, longitud);
                        drDireccion["TIPODOM"] = tipoDom;
                        //MessageBox.Show(tipoDom);
                        break;
                    case "11":
                        indEspDom = cadena.Substring(i, longitud);
                        drDireccion["INDESPDOM"] = indEspDom;
                        //MessageBox.Show(indEspDom);
                        break;
                    case "12":
                        fecDom = cadena.Substring(i, longitud);
                        drDireccion["FECDOM"] = fecDom;
                        //MessageBox.Show(fecDom);
                        break;
                }
                i += longitud;
                band = buscaSegmento(cadena.Substring(i, 2), Arr);

            } while (band);
            dtRepDireccion.Rows.Add(drDireccion);
            dsRepBuro.Tables["dtDireccion"].ImportRow(drDireccion);
        }

        public void segmentoEmpleo(string cadena, ref int i)
        {
            string[] Arr;

            string inicio = "PE,TL,IQ,RS,CR,SC,ES";
            Arr = inicio.Split(',');

            string seg = string.Empty;
            int longitud;
            Boolean band = true;
            do
            {
                seg = cadena.Substring(i, 2);
                i += 2;
                longitud = Convert.ToInt32(cadena.Substring(i, 2));
                i += 2;
                i += longitud;
                band = buscaSegmento(cadena.Substring(i, 2), Arr);

            } while (band);
        }

        public void segmentoCuenta(string cadena, ref int i)
        {
            string fecActualiza = string.Empty;
            string regImp = string.Empty;
            string cveOtorga = string.Empty;
            string nomOtorga = string.Empty;
            string idSIC = string.Empty;
            string cuenta = string.Empty;
            string tipoRespons = string.Empty;
            string tipoCuenta = string.Empty;
            string tipoContrato = string.Empty;
            string cveMoneda = string.Empty;
            string valorActivo = string.Empty;
            string numPagos = string.Empty;
            string frecPagos = string.Empty;
            string montoPagar = string.Empty;
            string fecCuenta = string.Empty;
            string fecUltPago = string.Empty;
            string fecUltCompra = string.Empty;
            string fecCierreCta = string.Empty;
            string fecRep = string.Empty;
            string modoRep = string.Empty;
            string fecCtaCero = string.Empty;
            string garantia = string.Empty;
            string credMax = string.Empty;
            string saldoAct = string.Empty;
            string limCred = string.Empty;
            string saldoVenc = string.Empty;
            string pagosVenc = string.Empty;
            string formaPago = string.Empty;   //MOP
            string histPago = string.Empty;
            string fecRecHistPago = string.Empty;
            string fecAntHistPago = string.Empty;
            string cveObs = string.Empty;
            string totalPagos = string.Empty;
            string totalPagosMOP02 = string.Empty;
            string totalPagosMOP03 = string.Empty;
            string totalPagosMOP04 = string.Empty;
            string totalPagosMOP05 = string.Empty;
            string impSaldoMora = string.Empty;
            string fecSaldoMora = string.Empty;
            string MOPHistorico = string.Empty;
            string fecRestruc = string.Empty;

            string[] Arr;

            string inicio = "TL,IQ,RS,CR,SC,ES";
            Arr = inicio.Split(',');

            dsBuro.dtCuentaDataTable dtCuenta = new dsBuro.dtCuentaDataTable();
            DataTable dtRepCuenta = (DataTable)dtCuenta;
            DataRow drCuenta = dtRepCuenta.NewRow();

            string seg = string.Empty;
            int longitud;
            Boolean band = true;
            do
            {
                seg = cadena.Substring(i, 2);
                i += 2;
                longitud = Convert.ToInt32(cadena.Substring(i, 2));
                i += 2;
                switch (seg)
                {
                    case "TL":
                        fecActualiza = cadena.Substring(i, longitud);
                        drCuenta["FECACTUALIZA"] = fecActualiza;
                        //MessageBox.Show(fecActualiza);
                        break;
                    case "00":
                        regImp = cadena.Substring(i, longitud);
                        drCuenta["REGIMP"] = regImp;
                        //MessageBox.Show(regImp);
                        break;
                    case "01":
                        cveOtorga = cadena.Substring(i, longitud);
                        drCuenta["CVEOTORGA"] = cveOtorga;
                        //MessageBox.Show(cveOtorga);
                        break;
                    case "02":
                        nomOtorga = cadena.Substring(i, longitud);
                        drCuenta["NOMOTORGA"] = nomOtorga;
                        //MessageBox.Show(nomOtorga);
                        break;
                    case "03":
                        idSIC = cadena.Substring(i, longitud);
                        drCuenta["IDSIC"] = idSIC;
                        //MessageBox.Show(idSIC);
                        break;
                    case "04":
                        cuenta = cadena.Substring(i, longitud);
                        drCuenta["CUENTA"] = cuenta;
                        //MessageBox.Show(cuenta);
                        break;
                    case "05":
                        tipoRespons = cadena.Substring(i, longitud);
                        drCuenta["TIPORESPONS"] = tipoRespons;
                        //MessageBox.Show(tipoRespons);
                        break;
                    case "06":
                        tipoCuenta = cadena.Substring(i, longitud);
                        drCuenta["TIPOCUENTA"] = tipoCuenta;
                        //MessageBox.Show(tipoCuenta);
                        break;
                    case "07":
                        tipoContrato = cadena.Substring(i, longitud);
                        drCuenta["TIPOCONTRATO"] = tipoContrato;
                        //MessageBox.Show(tipoContrato);
                        break;
                    case "08":
                        cveMoneda = cadena.Substring(i, longitud);
                        drCuenta["CVEMONEDA"] = cveMoneda;
                        //MessageBox.Show(cveMoneda);
                        break;
                    case "09":
                        valorActivo = cadena.Substring(i, longitud);
                        drCuenta["VALORACTIVO"] = valorActivo;
                        //MessageBox.Show(valorActivo);
                        break;
                    case "10":
                        numPagos = cadena.Substring(i, longitud);
                        drCuenta["NUMPAGOS"] = numPagos;
                        //MessageBox.Show(numPagos);
                        break;
                    case "11":
                        frecPagos = cadena.Substring(i, longitud);
                        drCuenta["FRECPAGOS"] = frecPagos;
                        //MessageBox.Show(frecPagos);
                        break;
                    case "12":
                        montoPagar = cadena.Substring(i, longitud);
                        drCuenta["MONTOPAGAR"] = montoPagar;
                        //MessageBox.Show(montoPagar);
                        break;
                    case "13":
                        fecCuenta = cadena.Substring(i, longitud);
                        drCuenta["FECCUENTA"] = fecCuenta;
                        //MessageBox.Show(fecCuenta);
                        break;
                    case "14":
                        fecUltPago = cadena.Substring(i, longitud);
                        drCuenta["FECULTPAGO"] = fecUltPago;
                        //MessageBox.Show(fecUltPago);
                        break;
                    case "15":
                        fecUltCompra = cadena.Substring(i, longitud);
                        drCuenta["FECULTCOMPRA"] = fecUltCompra;
                        //MessageBox.Show(fecUltCompra);
                        break;
                    case "16":
                        fecCierreCta = cadena.Substring(i, longitud);
                        drCuenta["FECCIERRECTA"] = fecCierreCta;
                        //MessageBox.Show(fecCierreCta);
                        break;
                    case "17":
                        fecRep = cadena.Substring(i, longitud);
                        drCuenta["FECREP"] = fecRep;
                        //MessageBox.Show(fecRep);
                        break;
                    case "18":
                        modoRep = cadena.Substring(i, longitud);
                        drCuenta["MODOREP"] = modoRep;
                        //MessageBox.Show(modoRep);
                        break;
                    case "19":
                        fecCtaCero = cadena.Substring(i, longitud);
                        drCuenta["FECCTACERO"] = fecCtaCero;
                        //MessageBox.Show(fecCtaCero);
                        break;
                    case "20":
                        garantia = cadena.Substring(i, longitud);
                        drCuenta["GARANTIA"] = garantia;
                        //MessageBox.Show(garantia);
                        break;
                    case "21":
                        credMax = cadena.Substring(i, longitud);
                        drCuenta["CREDMAX"] = credMax;
                        //MessageBox.Show(credMax);
                        break;
                    case "22":
                        saldoAct = cadena.Substring(i, longitud);
                        drCuenta["SALDOACT"] = saldoAct;
                        //MessageBox.Show(saldoAct);
                        break;
                    case "23":
                        limCred = cadena.Substring(i, longitud);
                        drCuenta["LIMCRED"] = limCred;
                        //MessageBox.Show(limCred);
                        break;
                    case "24":
                        saldoVenc = cadena.Substring(i, longitud);
                        drCuenta["SALDOVENC"] = saldoVenc;
                        //MessageBox.Show(saldoVenc);
                        break;
                    case "25":
                        pagosVenc = cadena.Substring(i, longitud);
                        drCuenta["PAGOSVENC"] = pagosVenc;
                        //MessageBox.Show(pagosVenc);
                        break;
                    case "26":
                        formaPago = cadena.Substring(i, longitud);
                        drCuenta["FORMAPAGO"] = formaPago;
                        //MessageBox.Show(formaPago);
                        break;
                    case "27":
                        histPago = cadena.Substring(i, longitud);
                        drCuenta["HISTPAGO"] = histPago;
                        string mes = "E,F,M,A,M,J,J,A,S,O,N,D";
                        string[] lstMes = mes.Split(',');
                        string diaAct = fecActualiza.Substring(0,2);
                        string mesAct = fecActualiza.Substring(2,2);
                        string aAct = fecActualiza.Substring(4,4);
                        string[] aHist = new string[3];
                        string[] mHist = new string[3];
                        string[] hist = new string[3];
                        DateTime d = Convert.ToDateTime(diaAct + "/" + mesAct + "/" + aAct);
                        d = d.AddMonths(-1);
                        DateTime dAnt = d;
                        int a = 0;
                        int n = 0;
                        int j = 0;
                        for (n = 0; n < histPago.Length; n++)
                        {
                            if (d.Year != dAnt.Year)
                            {
                                aHist[j] = d.Year.ToString();
                                j++;
                                d = dAnt;
                            }
                            mHist[j] += lstMes[dAnt.Month - 1];
                            hist[j] += histPago.Substring(n, 1);
                            dAnt = dAnt.AddMonths(-1);
                        }
                        
                        if (aHist[0] == null)
                            aHist[0] = d.Year.ToString();

                        for (j = 1; j < 3; j++)
                        {
                            if(aHist[j] == null)
                            {
                                a = Convert.ToInt32(aHist[j - 1]) - 1;
                                aHist[j] = a.ToString();
                            }
                        }
                        drCuenta["ANIO1"] = aHist[0];
                        drCuenta["ANIO2"] = aHist[1];
                        drCuenta["ANIO3"] = aHist[2];
                        drCuenta["MES1"] = mHist[0];
                        drCuenta["MES2"] = mHist[1];
                        drCuenta["MES3"] = mHist[2];
                        drCuenta["SEGMES1"] = hist[0];
                        drCuenta["SEGMES2"] = hist[1];
                        drCuenta["SEGMES3"] = hist[2];
                        break;
                    case "28":
                        fecRecHistPago = cadena.Substring(i, longitud);
                        drCuenta["FECRECHISTPAGO"] = fecRecHistPago;
                        break;
                    case "29":
                        fecAntHistPago = cadena.Substring(i, longitud);
                        drCuenta["FECANTHISTPAGO"] = fecAntHistPago;
                        //MessageBox.Show(fecAntHistPago);
                        break;
                    case "30":
                        cveObs = cadena.Substring(i, longitud);
                        drCuenta["CVEOBS"] = cveObs;
                        //MessageBox.Show(cveObs);
                        break;
                    case "31":
                        totalPagos = cadena.Substring(i, longitud);
                        drCuenta["TOTALPAGOS"] = totalPagos;
                        //MessageBox.Show(totalPagos);
                        break;
                    case "32":
                        totalPagosMOP02 = cadena.Substring(i, longitud);
                        drCuenta["TOTALPAGOSMOP02"] = totalPagosMOP02;
                        //MessageBox.Show(totalPagosMOP02);
                        break;
                    case "33":
                        totalPagosMOP03 = cadena.Substring(i, longitud);
                        drCuenta["TOTALPAGOSMOP03"] = totalPagosMOP03;
                        //MessageBox.Show(totalPagosMOP03);
                        break;
                    case "34":
                        totalPagosMOP04 = cadena.Substring(i, longitud);
                        drCuenta["TOTALPAGOSMOP04"] = totalPagosMOP04;
                        //MessageBox.Show(totalPagosMOP04);
                        break;
                    case "35":
                        totalPagosMOP05 = cadena.Substring(i, longitud);
                        drCuenta["TOTALPAGOSMOP05"] = totalPagosMOP05;    
                        //MessageBox.Show(totalPagosMOP05);
                        break;
                    case "36":
                        impSaldoMora = cadena.Substring(i, longitud);
                        drCuenta["IMPSALDOMORA"] = impSaldoMora;
                        //MessageBox.Show(impSaldoMora);
                        break;
                    case "37":
                        fecSaldoMora = cadena.Substring(i, longitud);
                        drCuenta["FECSALDOMORA"] = fecSaldoMora;
                        //MessageBox.Show(fecSaldoMora);
                        break;
                    case "38":
                        MOPHistorico = cadena.Substring(i, longitud);
                        drCuenta["MOPHISTORICO"] = MOPHistorico;
                        //MessageBox.Show(MOPHistorico);
                        break;
                    case "42":
                        fecRestruc = cadena.Substring(i, longitud);
                        drCuenta["FECRESTRUC"] = fecRestruc;
                        //MessageBox.Show(fecRestruc);
                        break;
                }
                i += longitud;
                band = buscaSegmento(cadena.Substring(i, 2), Arr);

            } while (band);
            dtRepCuenta.Rows.Add(drCuenta);
            dsRepBuro.Tables["dtCuenta"].ImportRow(drCuenta);
        }

        public void segmentoConsulta(string cadena, ref int i)
        {
            string fecConsulta = string.Empty;
            string idBuro = string.Empty;
            string cveOtorga = string.Empty;
            string nomOtorga = string.Empty;
            string telOtorga = string.Empty;
            string tipoContrato = string.Empty;
            string cveMoneda = string.Empty;
            string importe = string.Empty;
            string tipoRespons = string.Empty;
            string consNuevo = string.Empty;
            string resFinal = string.Empty;
            
            string[] Arr;

            string inicio = "IQ,RS,CR,SC,ES";
            Arr = inicio.Split(',');

            dsBuro.dtConsultaDataTable dtConsulta = new dsBuro.dtConsultaDataTable();
            DataTable dtRepConsulta = (DataTable)dtConsulta;
            DataRow drConsulta = dtRepConsulta.NewRow();

            string seg = string.Empty;
            int longitud;
            Boolean band = true;
            do
            {
                seg = cadena.Substring(i, 2);
                i += 2;
                longitud = Convert.ToInt32(cadena.Substring(i, 2));
                i += 2;
                switch (seg)
                {
                    case "IQ":
                        fecConsulta = cadena.Substring(i, longitud);
                        drConsulta["FECREGCONS"] = fecConsulta;
                        break;
                    case "00":
                        idBuro = cadena.Substring(i, longitud);
                        drConsulta["IDBURO"] = idBuro;
                        break;
                    case "01":
                        cveOtorga = cadena.Substring(i, longitud);
                        drConsulta["CVEOTORGA"] = cveOtorga;
                        break;
                    case "02":
                        nomOtorga = cadena.Substring(i, longitud);
                        drConsulta["NOMOTORGA"] = nomOtorga;
                        break;
                    case "03":
                        telOtorga = cadena.Substring(i, longitud);
                        drConsulta["TELOTORGA"] = telOtorga;
                        break;
                    case "04":
                        tipoContrato = cadena.Substring(i, longitud);
                        drConsulta["TIPOCONTRATO"] = tipoContrato;
                        break;
                    case "05":
                        cveMoneda = cadena.Substring(i, longitud);
                        drConsulta["CVEMONEDA"] = cveMoneda;
                        break;
                    case "06":
                        importe = cadena.Substring(i, longitud);
                        drConsulta["IMPORTE"] = importe;
                        break;
                    case "07":
                        tipoRespons = cadena.Substring(i, longitud);
                        drConsulta["TIPORESPONS"] = tipoRespons;
                        break;
                    case "08":
                        consNuevo = cadena.Substring(i, longitud);
                        drConsulta["CONSNUEVO"] = consNuevo;
                        break;
                    case "09":
                        resFinal = cadena.Substring(i, longitud);
                        drConsulta["RESFINAL"] = resFinal;
                        break;
                }
                i += longitud;
                band = buscaSegmento(cadena.Substring(i, 2), Arr);
            } while (band);
            dtRepConsulta.Rows.Add(drConsulta);
            dsRepBuro.Tables["dtConsulta"].ImportRow(drConsulta);
        }

        public void segmentoResumen(string cadena, ref int i)
        {
            string fecRegBuro = string.Empty;
            string numMOP07 = string.Empty;
            string numMOP06 = string.Empty;
            string numMOP05 = string.Empty;
            string numMOP04 = string.Empty;
            string numMOP03 = string.Empty;
            string numMOP02 = string.Empty;
            string numMOP01 = string.Empty;
            string numMOP00 = string.Empty;
            string numMOPUR = string.Empty;
            string numCtas = string.Empty;
            string numCtasFijos = string.Empty;
            string numCtasRev = string.Empty;
            string numCtasCer = string.Empty;
            string numCtasNeg = string.Empty;
            string numCtasMOP = string.Empty;
            string numCtasDisp = string.Empty;
            string numSolic = string.Empty;
            string indNvaDir = string.Empty;
            string mensaje = string.Empty;
            string indExistDec = string.Empty;
            string cveMoneda = string.Empty;
            string totCredMaxRev = string.Empty;
            string totLimCredRev = string.Empty;
            string totSdoActRev = string.Empty;
            string totSdoVenvRev = string.Empty;
            string totPagosRev = string.Empty;
            string porcLimCredRev = string.Empty;   
            string totCredMaxFijos = string.Empty;
            string totSdoActFijos = string.Empty;
            string totSdoVencFijos = string.Empty;
            string impTotPagFijos = string.Empty;
            string numMOP96 = string.Empty;
            string numMOP97 = string.Empty;
            string numMOP99 = string.Empty;
            string fecCtaAnt = string.Empty;
            string fecCtaRec = string.Empty;
            string numTotSolicRep = string.Empty;
            string fecRecRep = string.Empty;
            string numTotCtasCob = string.Empty;
            string fecCtaRecCob = string.Empty;
            string numTotSolicCob = string.Empty;
            string fecSolicCob = string.Empty;

            string[] Arr;

            string inicio = "RS,CR,SC,ES";
            Arr = inicio.Split(',');

            dsBuro.dtResumenDataTable dtResumen = new dsBuro.dtResumenDataTable();
            DataTable dtRepResumen = (DataTable)dtResumen;
            DataRow drResumen = dtRepResumen.NewRow();

            string seg = string.Empty;
            int longitud;
            Boolean band = true;
            do
            {
                seg = cadena.Substring(i, 2);
                i += 2;
                longitud = Convert.ToInt32(cadena.Substring(i, 2));
                i += 2;
                /*switch (seg)
                {
                    case "RS":
                        fecRecRep = cadena.Substring(i, longitud);
                        drResumen["FECREGBURO"] = fecRecRep;
                        break;
                    case "00":
                        numMOP07 = cadena.Substring(i, longitud);
                        drResumen["NUMMOP07"] = numMOP07;
                        break;
                    case "01":
                        numMOP06 = cadena.Substring(i, longitud);
                        drResumen["NUMMOP06"] = numMOP06;
                        break;
                    case "02":
                        numMOP05 = cadena.Substring(i, longitud);
                        drResumen["NUMMOP05"] = numMOP05;
                        break;
                    case "03":
                        numMOP04 = cadena.Substring(i, longitud);
                        drResumen["NUMMOP04"] = numMOP04;
                        break;
                    case "04":
                        numMOP03 = cadena.Substring(i, longitud);
                        drResumen["NUMMOP03"] = numMOP03;
                        break;
                    case "05":
                        numMOP02 = cadena.Substring(i, longitud);
                        drResumen["NUMMOP02"] = numMOP02;
                        break;
                    case "06":
                        numMOP01 = cadena.Substring(i, longitud);
                        drResumen["NUMMOP01"] = numMOP01;
                        break;
                    case "07":
                        numMOP00 = cadena.Substring(i, longitud);
                        drResumen["NUMMOP00"] = numMOP00;
                        break;
                    case "08":
                        numMOPUR = cadena.Substring(i, longitud);
                        drResumen["NUMMOPUR"] = numMOPUR;
                        break;
                    case "09":
                        numCtas = cadena.Substring(i, longitud);
                        drResumen["NUMCTAS"] = numCtas;
                        break;
                    case "10":
                        numCtasFijos = cadena.Substring(i, longitud);
                        drResumen["NUMCTASFIJOS"] = numCtasFijos;
                        break;
                    case "11":
                        numCtasRev = cadena.Substring(i, longitud);
                        drResumen["NUMCTASREV"] = numCtasRev;
                        break;
                    case "12":
                        numCtasCer = cadena.Substring(i, longitud);
                        drResumen["NUMCTASCER"] = numCtasCer;
                        break;
                    case "13":
                        numCtasNeg = cadena.Substring(i, longitud);
                        drResumen["NUMCTASNEG"] = numCtasNeg;
                        break;
                    case "14":
                        numCtasMOP = cadena.Substring(i, longitud);
                        drResumen["NUMCTASMOP"] = numCtasMOP;
                        break;
                    case "15":
                        numCtasDisp = cadena.Substring(i, longitud);
                        drResumen["NUMCTASDISP"] = numCtasDisp;
                        break;
                    case "16":
                        numSolic = cadena.Substring(i, longitud);
                        drResumen["NUMSOLIC"] = numSolic;
                        break;
                    case "17":
                        indNvaDir = cadena.Substring(i, longitud);
                        drResumen["INDNVADIR"] = indNvaDir;
                        break;
                    case "18":
                        mensaje = cadena.Substring(i, longitud);
                        drResumen["MENSAJE"] = mensaje;
                        break;
                    case "19":
                        indExistDec = cadena.Substring(i, longitud);
                        drResumen["INDEXISTDEC"] = indExistDec;
                        break;
                    case "20":
                        cveMoneda = cadena.Substring(i, longitud);
                        drResumen["CVEMONEDA"] = cveMoneda;
                        break;
                    case "21":
                        totCredMaxRev = cadena.Substring(i, longitud);
                        drResumen["TOTCREDMAXREV"] = totCredMaxRev;
                        break;
                    case "22":
                        totLimCredRev = cadena.Substring(i, longitud);
                        drResumen["TOTLIMCREDREV"] = totLimCredRev;
                        break;
                    case "23":
                        totSdoActRev = cadena.Substring(i, longitud);
                        drResumen["TOTSDOACTREV"] = totSdoActRev;
                        break;
                    case "24":
                        totSdoVenvRev = cadena.Substring(i, longitud);
                        drResumen["TOTSDOVENCREV"] = totSdoVenvRev;
                        break;
                    case "25":
                        totPagosRev = cadena.Substring(i, longitud);
                        drResumen["TOTPAGREV"] = totPagosRev;
                        break;
                    case "26":
                        porcLimCredRev = cadena.Substring(i, longitud);
                        drResumen["PORCLIMCREDREV"] = porcLimCredRev;
                        break;
                    case "27":
                        totCredMaxFijos = cadena.Substring(i, longitud);
                        drResumen["TOTCREDMAXFIJOS"] = totCredMaxFijos;
                        break;
                    case "28":
                        totSdoActFijos = cadena.Substring(i, longitud);
                        drResumen["TOTSDOACTFIJOS"] = totSdoActFijos;
                        break;
                    case "29":
                        totSdoVencFijos = cadena.Substring(i, longitud);
                        drResumen["TOTSDOVENCFIJOS"] = totSdoVencFijos;
                        break;
                    case "30":
                        impTotPagFijos = cadena.Substring(i, longitud);
                        drResumen["IMPTOTPAGFIJOS"] = impTotPagFijos;
                        break;
                    case "31":
                        numMOP96 = cadena.Substring(i, longitud);
                        drResumen["NUMMOP96"] = numMOP96;
                        break;
                    case "32":
                        numMOP97 = cadena.Substring(i, longitud);
                        drResumen["NUMMOP97"] = numMOP97;
                        break;
                    case "33":
                        numMOP99 = cadena.Substring(i, longitud);
                        drResumen["NUMMOP99"] = numMOP99;
                        break;
                    case "34":
                        fecCtaAnt = cadena.Substring(i, longitud);
                        drResumen["FECCTAANT"] = fecCtaAnt;
                        break;
                    case "35":
                        fecCtaRec = cadena.Substring(i, longitud);
                        drResumen["FECCTAREC"] = fecCtaRec;
                        break;
                    case "36":
                        numTotSolicRep = cadena.Substring(i, longitud);
                        drResumen["NUMTOTSOLICREP"] = numTotSolicRep;
                        break;
                    case "37":
                        fecRecRep = cadena.Substring(i, longitud);
                        drResumen["FECRECREP"] = fecRecRep;
                        break;
                    case "38":
                        numTotCtasCob = cadena.Substring(i, longitud);
                        drResumen["NUMTOTCTASCOB"] = numTotCtasCob;
                        break;
                    case "39":
                        fecCtaRecCob = cadena.Substring(i, longitud);
                        drResumen["FECCTARECCOB"] = fecCtaRecCob;
                        break;
                    case "40":
                        numTotSolicCob = cadena.Substring(i, longitud);
                        drResumen["NUMTOTSOLICCOB"] = numTotSolicCob;
                        break;
                    case "41":
                        fecSolicCob = cadena.Substring(i, longitud);
                        drResumen["FECSOLICCOB"] = fecSolicCob;
                        break;
                }*/
                i += longitud;
                band = buscaSegmento(cadena.Substring(i, 2), Arr);
            } while (band);
            //dtRepResumen.Rows.Add(drResumen);
            //dsRepBuro.Tables["dtResumen"].ImportRow(drResumen);
        }

        public void segmentoDeclaracion(string cadena, ref int i, int cont)
        {
            string seg = string.Empty;
            int longitud;
            
            seg = cadena.Substring(i, 2);
            i += 2;
            longitud = Convert.ToInt32(cadena.Substring(i, 2));
            i += 2;
            i += longitud;
            i += 4;         //"0000" VALOR ASIGNADO POR DEFECTO
            i += (cont - 28) - i;
        }

        public void segmentoScore(string cadena, ref int i)
        {
            string[] Arr;

            string inicio = "ES";
            Arr = inicio.Split(',');

            string seg = string.Empty;
            int longitud;
            Boolean band = true;
            do
            {
                seg = cadena.Substring(i, 2);
                i += 2;
                longitud = Convert.ToInt32(cadena.Substring(i, 2));
                i += 2;
                i += longitud;
                band = buscaSegmento(cadena.Substring(i, 2), Arr);

            } while (band);
        }

        public void segmentoFin(string cadena, ref int i)
        {
            string caract = string.Empty;             //FIJO CON 5 CARACTERES
            string numControl = string.Empty;         //FIJO CON 9 CARACTERES

            i += 4;
            caract = cadena.Substring(i, 5);
            //INCREMENTA i EN 9 POSICIONES 
            //(5 POSICIONES DE NUMERO DE CARACTERES, 4 POSICIONES DE ETIQUETA 0009)
            i += 9;
            numControl = cadena.Substring(i, 9);
            i += 15;
        }

        public Boolean buscaSegmento(string segmento, string[] Arr)
        {
            int i;
            int ind;
            for (i = 0; i < Arr.Length; i++)
            {
                ind = segmento.IndexOf(Arr[i]);
                if (ind >= 0)
                {
                    return false;
                }
            }
            return true;
        }
}
