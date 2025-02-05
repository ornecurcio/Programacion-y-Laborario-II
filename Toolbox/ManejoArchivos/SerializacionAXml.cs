﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ManejoArchivos
{
    public class SerializacionAXml
    {
        /// <summary>
        /// Genera Archivo Xml
        /// </summary>
        /// <param name="ruta">donde se guardara el archivo/param>
        /// <param name="obj">el objeto a serializar</param>
        public static void SerializarAXmlLista<T>(string ruta, T obj) where T : new()
        {
            XmlTextWriter xmlWriter = null;
            XmlSerializer serializador = null;
            try
            {
                xmlWriter = new XmlTextWriter(ruta, Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                serializador = new XmlSerializer(typeof(T));
                serializador.Serialize(xmlWriter, obj);
            }
            catch (Exception ex)
            {
                throw new SerializacionException(ex.Message);
            }
            finally
            {
                if (xmlWriter != null)
                {
                    xmlWriter.Close();
                }
            }
        }
        /// <summary>
        /// Deserealiza un archivo Xml
        /// </summary>
        /// <param name="ruta">donde esta el archivo</param>
        /// <returns>el objeto deserealizado</returns>
        public static T DeserealizarXml<T>(string ruta) where T : new()
        {
            XmlTextReader xmlReader = null;
            XmlSerializer serializador = null;
            try
            {
                xmlReader = new XmlTextReader(ruta);
                serializador = new XmlSerializer(typeof(T));
                T objetoDesealizado = (T)serializador.Deserialize(xmlReader);
                return objetoDesealizado;
            }
            catch (Exception ex)
            {
                throw new SerializacionException(ex.Message);
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
            }
        }

        public bool SerializarXml(string path)
        {
            bool retorno = false;
            try
            {

                if (path != null)
                {
                    using (StreamWriter streamWriter = new StreamWriter(path))
                    {
                        XmlSerializer nuevoXml = new XmlSerializer(typeof(Generica<T, U>));
                        nuevoXml.Serialize(streamWriter, this);
                        retorno = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SerializacionException(ex.Message);
            }
            return retorno;
        }

        public bool DeserializarXml(string path, out Generica<T, U> datos)
        {
            bool retorno = false;
            datos = default;

            try
            {
                if (path != null)
                {
                    using (StreamReader auxReader = new StreamReader(path))
                    {
                        XmlSerializer nuevoXml = new XmlSerializer(typeof(Generica<T, U>));
                        datos = (Generica<T, U>)nuevoXml.Deserialize(auxReader);
                        retorno = true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new SerializacionException(ex.Message);
            }

            return retorno;
        }

    }
}
