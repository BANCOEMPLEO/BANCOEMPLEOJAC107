using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANCOEMPLEOJAC.Modelo;
using BANCOEMPLEOJAC.Repositorio.Contrato;
using BANCOEMPLEOJAC.Repositorio.DBContext;


namespace BANCOEMPLEOJAC.Repositorio.Implementacion
{
    public class VentaRepositorio : GenericoRepositorio<Venta>, IVentaRepositorio
    {
        private readonly BancoEmpleoJac01Context _dbContext;
        public VentaRepositorio(BancoEmpleoJac01Context dbContext) :base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventagenerada = new Venta();
            using (var transaccion = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach(DetalleVenta dv in modelo.DetalleVenta)
                    {
                        Producto producto_encontrado = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();

                        producto_encontrado.Cantidad = producto_encontrado.Cantidad - dv.Cantidad;
                        _dbContext.Productos.Update(producto_encontrado);

                    }
                    await _dbContext.SaveChangesAsync();
                    
                    await _dbContext.Venta.AddAsync(modelo);
                    await _dbContext.SaveChangesAsync();
                    ventagenerada = modelo;
                    transaccion.Commit();

                }
                catch 
                {
                    transaccion.Rollback();
                    throw;
                }
            }
            return ventagenerada;
        }
    }
}
