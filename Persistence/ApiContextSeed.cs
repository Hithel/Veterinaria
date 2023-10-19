
using System.Globalization;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Persistence;
    public class ApiContextSeed
    {
        public static async Task SeedAsync(ApiContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (!context.Users.Any())
            {
                using (var readerEntity = new StreamReader("../Persistence/Data/Csvs/User.Csv"))
                {
                    using (var csv = new CsvReader(readerEntity, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<User>();
                        context.Users.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            } 


            if (!context.Veterinarios.Any())
            {
                using (var readerEntity = new StreamReader("../Persistence/Data/Csvs/Veterinario.Csv"))
                {
                    using (var csv = new CsvReader(readerEntity, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Veterinario>();
                        context.Veterinarios.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            } 

            if (!context.Especies.Any())
            {
                using (var readerEntity = new StreamReader("../Persistence/Data/Csvs/Especie.Csv"))
                {
                    using (var csv = new CsvReader(readerEntity, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Especie>();
                        context.Especies.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.Propietarios.Any())
            {
                using (var readerEntity = new StreamReader("../Persistence/Data/Csvs/Propietario.Csv"))
                {
                    using (var csv = new CsvReader(readerEntity, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Propietario>();
                        context.Propietarios.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            } 
            if (!context.Razas.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/Raza.Csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Raza>();
                        List<Raza> entidad = new List<Raza>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Raza
                            {
                                Id = item.Id,
                                IdEspecieFK = item.IdEspecieFK,
                                Descripcion = item.Descripcion
                            });
                        }
                        context.Razas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

           if (!context.Mascotas.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/Mascota.Csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Mascota>();
                        List<Mascota> entidad = new List<Mascota>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Mascota
                            {
                                Id = item.Id,
                                IdPropietarioFk = item.IdPropietarioFk,
                                IdRazaFK = item.IdRazaFK,
                                Nombre = item.Nombre,
                                FechaNacimineto = item.FechaNacimineto,
                            });
                        }
                        context.Mascotas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }


            if (!context.Citas.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/Citas.Csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Citas>();
                        List<Citas> entidad = new List<Citas>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Citas
                            {
                                Id = item.Id,
                                Fecha = item.Fecha,
                                Motivo = item.Motivo,
                                IdMascotaFk = item.IdMascotaFk,
                                IdVeterinarioFK = item.IdVeterinarioFK,
                                IdUserFK = item.IdUserFK
                            });
                        }
                        context.Citas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.Proveedores.Any())
            {
                using (var readerEntity = new StreamReader("../Persistence/Data/Csvs/Proveedor.csv"))
                {
                    using (var csv = new CsvReader(readerEntity, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Proveedor>();
                        context.Proveedores.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.Laboratorios.Any())
            {
                using (var readerEntity = new StreamReader("../Persistence/Data/Csvs/Laboratorio.csv"))
                {
                    using (var csv = new CsvReader(readerEntity, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Laboratorio>();
                        context.Laboratorios.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }

             if (!context.Medicamentos.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/Medicamento.Csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Medicamento>();
                        List<Medicamento> entidad = new List<Medicamento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Medicamento
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                Cantidad = item.Cantidad,
                                Precio = item.Precio,
                                IdLaboratorioFk = item.IdLaboratorioFk
                            });
                        }
                        context.Medicamentos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.MedicamentoProveedores.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/MedicamentoProveedor.Csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<MedicamentoProveedor>();
                        List<MedicamentoProveedor> entidad = new List<MedicamentoProveedor>();
                        foreach (var item in list)
                        {
                            entidad.Add(new MedicamentoProveedor
                            {
                                IdMedicamentoFk = item.IdMedicamentoFk,
                                IdProveedorFk = item.IdProveedorFk
                            });
                        }
                        context.MedicamentoProveedores.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.TratamientoMedicos.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/TratamientoMedico.Csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<TratamientoMedico>();
                        List<TratamientoMedico> entidad = new List<TratamientoMedico>();
                        foreach (var item in list)
                        {
                            entidad.Add(new TratamientoMedico
                            {
                                Id = item.Id,
                                IdMascotaFK = item.IdMascotaFK,
                                IdMedicamentoFk = item.IdMedicamentoFk,
                                Dosis = item.Dosis,
                                FechaAdministracion = item.FechaAdministracion,
                                Descripcion = item.Descripcion
                            });
                        }
                        context.TratamientoMedicos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.TipoMovimientos.Any())
            {
                using (var readerEntity = new StreamReader("../Persistence/Data/Csvs/TipoMovimiento.csv"))
                {
                    using (var csv = new CsvReader(readerEntity, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<TipoMovimiento>();
                        context.TipoMovimientos.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.Movimientos.Any())
{
                using (var reader = new StreamReader("../Persistence/Data/Csvs/Movimiento.Csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Movimiento>();
                        List<Movimiento> entidad = new List<Movimiento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Movimiento
                            {
                                Id = item.Id,
                                IdTipoMovimientoFK = item.IdTipoMovimientoFK,
                                PrecioTotal = item.PrecioTotal
                            });
                        }
                        context.Movimientos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.DetalleMovimientos.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/DetalleMovimiento.Csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<DetalleMovimiento>();
                        List<DetalleMovimiento> entidad = new List<DetalleMovimiento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new DetalleMovimiento
                            {
                                Id = item.Id,
                                IdMedicamentoFk = item.IdMedicamentoFk,
                                Cantidad = item.Cantidad,
                                IdMovimientoFK = item.IdMovimientoFK,
                                PrecioUnitario = item.PrecioUnitario,
                                Fecha = item.Fecha
                            });
                        }
                        context.DetalleMovimientos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }            

            if (!context.UsersRols.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/UserRol.Csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<UserRol>();
                        List<UserRol> entidad = new List<UserRol>();
                        foreach (var item in list)
                        {
                            entidad.Add(new UserRol
                            {
                                UsuarioId = item.UsuarioId,
                                RolId = item.RolId
                            });
                        }
                        context.UsersRols.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
             
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiContext>();
            logger.LogError(ex.Message);
        }
    }
    public static async Task SeedRolesAsync(ApiContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Rols.Any())
            {
                var roles = new List<Rol>()
                        {
                            new Rol{Id=1, Nombre="Administrator"},
                            new Rol{Id=2, Nombre="Manager"},
                            new Rol{Id=3, Nombre="Employee"}
                        };
                context.Rols.AddRange(roles);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiContext>();
            logger.LogError(ex.Message);
        }
    }
    }
