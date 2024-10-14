using System;
using System.Collections.Generic;  // Ensure this is imported for List<T>
using mandrilAPI.Models;

namespace mandrilAPI.Services
{
    public class MandrilDataStore
    {
        public List<Mandril> Mandriles { get; set; }
        public static MandrilDataStore Current { get; set; } = new MandrilDataStore();

        public MandrilDataStore()
        {
            Mandriles = new List<Mandril>()
            {
                new Mandril() {
                    Id = 1,
                    Name = "Mini Mandril",
                    Apellido = "Rodriguez",
                    Habilidades = new List<Habilidad>() {
                        new Habilidad() { 
                            Id = 1, 
                            Nombre = "Saltar",
                            Potencia = Habilidad.EPotencia.Moderado
                        }
                    }
                },
                new Mandril() { 
                    Id = 2, 
                    Name = "Supermandril",
                    Apellido = "Fernandez",
                    Habilidades = new List<Habilidad>() {
                        new Habilidad() { 
                            Id = 1, 
                            Nombre = "Saltar",
                            Potencia = Habilidad.EPotencia.Moderado
                        },
                        new Habilidad() { 
                            Id = 2, 
                            Nombre = "Caminar",
                            Potencia = Habilidad.EPotencia.Intenso
                        },
                        new Habilidad() {
                            Id = 3, 
                            Nombre = "Gritar",
                            Potencia = Habilidad.EPotencia.RePotente
                        }
                    }
                },
                new Mandril() {
                    Id = 3,
                    Name = "MegaMandril",
                    Apellido = "Legrand",
                    Habilidades = new List<Habilidad>() {
                        new Habilidad() { 
                            Id = 1, 
                            Nombre = "Nadar",
                            Potencia = Habilidad.EPotencia.Moderado
                        },
                        new Habilidad() { 
                            Id = 2, 
                            Nombre = "Correr",
                            Potencia = Habilidad.EPotencia.Intenso
                        },
                        new Habilidad() {
                            Id = 3, 
                            Nombre = "Vomitar",
                            Potencia = Habilidad.EPotencia.RePotente
                        }
                    }
                }
            };
        }
    }
}
