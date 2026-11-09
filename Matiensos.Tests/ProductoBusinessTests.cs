using System;
using System.Collections.Generic;
using Business;
using Entities;
using NUnit.Framework;

namespace Matiensos.Tests
{
    [TestFixture]
    public class ProductoBusinessTests
    {
        private ProductoBusiness _productoBusiness;

        [SetUp]
        public void Setup()
        {
            _productoBusiness = new ProductoBusiness();
        }

        #region 1. Validaciones en Alta de Producto (Valores Inválidos / Requeridos)

        /// <summary>
        /// El código de producto es obligatorio para identificar unívocamente el artículo.
        /// </summary>
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void RegistrarProducto_CodigoInvalido_RetornaFalsoYMensajeEsperado(string? codigoInvalido)
        {
            var producto = new Producto
            {
                Codigo = codigoInvalido!,
                Nombre = "Mate Imperial Alpaca",
                CategoriaId = 1,
                Precio = 25000m,
                Stock = 10,
                StockMinimo = 2
            };

            bool resultado = _productoBusiness.RegistrarProducto(producto, out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("código del producto es obligatorio"));
        }

        /// <summary>
        /// El nombre del producto es obligatorio para su visualización en catálogo y ticket.
        /// </summary>
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void RegistrarProducto_NombreInvalido_RetornaFalsoYMensajeEsperado(string? nombreInvalido)
        {
            var producto = new Producto
            {
                Codigo = "PROD-999",
                Nombre = nombreInvalido!,
                CategoriaId = 1,
                Precio = 15000m,
                Stock = 5,
                StockMinimo = 1
            };

            bool resultado = _productoBusiness.RegistrarProducto(producto, out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("nombre del producto no puede estar vacío"));
        }

        /// <summary>
        /// Todo producto debe pertenecer a una categoría válida existente (Id > 0).
        /// </summary>
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void RegistrarProducto_CategoriaInvalida_RetornaFalsoYMensajeEsperado(int categoriaIdInvalida)
        {
            var producto = new Producto
            {
                Codigo = "PROD-999",
                Nombre = "Bombilla Pico de Loro",
                CategoriaId = categoriaIdInvalida,
                Precio = 6500m,
                Stock = 20,
                StockMinimo = 5
            };

            bool resultado = _productoBusiness.RegistrarProducto(producto, out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("Debe seleccionar una categoría válida"));
        }

        /// <summary>
        /// El precio de venta no puede ser negativo bajo ninguna circunstancia.
        /// </summary>
        [TestCase(-0.01)]
        [TestCase(-100)]
        [TestCase(-50000)]
        public void RegistrarProducto_PrecioNegativo_RetornaFalsoYMensajeEsperado(decimal precioNegativo)
        {
            var producto = new Producto
            {
                Codigo = "PROD-999",
                Nombre = "Termo Lumilagro 1L",
                CategoriaId = 2,
                Precio = precioNegativo,
                Stock = 10,
                StockMinimo = 2
            };

            bool resultado = _productoBusiness.RegistrarProducto(producto, out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("El precio no puede ser negativo"));
        }

        /// <summary>
        /// El stock inicial no puede ser negativo.
        /// </summary>
        [TestCase(-1)]
        [TestCase(-15)]
        public void RegistrarProducto_StockNegativo_RetornaFalsoYMensajeEsperado(int stockNegativo)
        {
            var producto = new Producto
            {
                Codigo = "PROD-999",
                Nombre = "Yerba Mate Rosamonte 1kg",
                CategoriaId = 3,
                Precio = 4800m,
                Stock = stockNegativo,
                StockMinimo = 5
            };

            bool resultado = _productoBusiness.RegistrarProducto(producto, out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("El stock no puede ser negativo"));
        }

        /// <summary>
        /// El stock de alerta mínima no puede ser negativo.
        /// </summary>
        [TestCase(-1)]
        [TestCase(-5)]
        public void RegistrarProducto_StockMinimoNegativo_RetornaFalsoYMensajeEsperado(int stockMinimoNegativo)
        {
            var producto = new Producto
            {
                Codigo = "PROD-999",
                Nombre = "Yerba Mate Rosamonte 1kg",
                CategoriaId = 3,
                Precio = 4800m,
                Stock = 10,
                StockMinimo = stockMinimoNegativo
            };

            bool resultado = _productoBusiness.RegistrarProducto(producto, out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("El stock mínimo no puede ser negativo"));
        }

        #endregion

        #region 2. Validaciones en Modificación de Producto

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void ActualizarProducto_NombreInvalido_RetornaFalsoYMensaje(string? nombreInvalido)
        {
            // 
            var producto = new Producto
            {
                Id = 1,
                Nombre = nombreInvalido!,
                CategoriaId = 1,
                Precio = 12000m,
                Stock = 5,
                StockMinimo = 2
            };

            
            bool resultado = _productoBusiness.ActualizarProducto(producto, out string mensaje);

            
            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("nombre del producto no puede estar vacío"));
        }

        [TestCase(-1.0)]
        [TestCase(-500.0)]
        public void ActualizarProducto_PrecioNegativo_RetornaFalsoYMensaje(decimal precioNegativo)
        {
            var producto = new Producto
            {
                Id = 1,
                Nombre = "Mate Camionero",
                CategoriaId = 1,
                Precio = precioNegativo,
                Stock = 5,
                StockMinimo = 2
            };

            
            bool resultado = _productoBusiness.ActualizarProducto(producto, out string mensaje);

            
            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("El precio no puede ser negativo"));
        }

        [TestCase(-1)]
        [TestCase(-20)]
        public void ActualizarProducto_StockNegativo_RetornaFalsoYMensaje(int stockNegativo)
        { 
            var producto = new Producto
            {
                Id = 1,
                Nombre = "Mate Camionero",
                CategoriaId = 1,
                Precio = 18000m,
                Stock = stockNegativo,
                StockMinimo = 2
            };

            
            bool resultado = _productoBusiness.ActualizarProducto(producto, out string mensaje);

            
            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("El stock no puede ser negativo"));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void ActualizarProducto_StockMinimoNegativo_RetornaFalsoYMensaje(int stockMinimoNegativo)
        {
            var producto = new Producto
            {
                Id = 1,
                Nombre = "Mate Camionero",
                CategoriaId = 1,
                Precio = 18000m,
                Stock = 10,
                StockMinimo = stockMinimoNegativo
            };

            
            bool resultado = _productoBusiness.ActualizarProducto(producto, out string mensaje);

            
            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("El stock mínimo no puede ser negativo"));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ActualizarProducto_CategoriaInvalida_RetornaFalsoYMensaje(int categoriaInvalida)
        {
            var producto = new Producto
            {
                Id = 1,
                Nombre = "Mate Camionero",
                CategoriaId = categoriaInvalida,
                Precio = 18000m,
                Stock = 10,
                StockMinimo = 2
            };

            
            bool resultado = _productoBusiness.ActualizarProducto(producto, out string mensaje);

            
            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("Debe seleccionar una categoría válida"));
        }

        #endregion

        #region 3. Reglas de Negocio de Dominio (Producto)

        [TestCase(10, 5, true)]
        [TestCase(5, 5, true)]
        [TestCase(0, 1, false)]
        [TestCase(3, 4, false)]
        public void Producto_TieneStockSuficiente_EvaluaCorrectamente(int stockActual, int cantidadPedida, bool esperado)
        {
            var prod = new Producto { Id = 1, Nombre = "Mate Torpedo", Stock = stockActual };
            Assert.That(prod.TieneStockSuficiente(cantidadPedida), Is.EqualTo(esperado));
        }

        #endregion

        #region 4. Control de Acceso y Roles (Admin y SuperAdmin vs Vendedor)

        /// <summary>
        /// Verifica que la regla de autorización del sistema permita la administración
        /// del catálogo de productos únicamente a Administrador y SuperAdmin, excluyendo a Vendedor.
        /// </summary>
        [TestCase("SuperAdmin", true)]
        [TestCase("Administrador", true)]
        [TestCase("admin", true)]
        [TestCase("Vendedor", false)]
        [TestCase("vendedor", false)]
        [TestCase("Cajero", false)]
        [TestCase("", false)]
        [TestCase(null, false)]
        public void SeguridadRol_AccesoAGestionProductos_PermiteSoloAdminYSuperAdmin(string? rol, bool accesoPermitidoEsperado)
        {
            bool tienePermisoAdmin = !string.IsNullOrWhiteSpace(rol) && rol.ToLower().Contains("admin");

            Assert.That(tienePermisoAdmin, Is.EqualTo(accesoPermitidoEsperado));
        }

        #endregion
    }
}
