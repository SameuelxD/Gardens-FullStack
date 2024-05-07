<template>
    <div class="container">
        <h2 class="item_title">Información del Producto más Vendido</h2>
        <table class="table table-dark">
            <thead>
                <tr>
                    <th scope="col">Código Producto</th>
                    <th scope="col">Nombre</th>
                    <th scope="col">Gama</th>
                    <th scope="col">Dimensiones</th>
                    <th scope="col">Proveedor</th>
                    <th scope="col">Descripción</th>
                    <th scope="col">Cantidad Vendida</th>
                </tr>
            </thead>
            <tbody>
                <tr v-if="productoMasVendido" :key="productoMasVendido.codigoProducto">
                    <td>{{ productoMasVendido.codigoProducto }}</td>
                    <td>{{ productoMasVendido.nombre }}</td>
                    <td>{{ productoMasVendido.gama }}</td>
                    <td>{{ productoMasVendido.dimensiones }}</td>
                    <td>{{ productoMasVendido.proveedor }}</td>
                    <td>{{ productoMasVendido.descripcion }}</td>
                    <td>{{ productoMasVendido.cantidad }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import axios from 'axios';
import Swal from 'sweetalert2';

export default {
    name: 'ProductoMasVendido',
    data() {
        return {
            productoMasVendido: null,
            API_URL: process.env.VUE_APP_API_URL,
            API_IIS: process.env.VUE_APP_API_IIS
        };
    },
    created() {
        this.fetchProductoMasVendido();
    },
    methods: {
        fetchProductoMasVendido() {
            axios.get(this.API_IIS + '/api/Producto/ProductoMasVendido', { withCredentials: true })
                .then(response => {
                    this.productoMasVendido = response.data;
                })
                .catch(error => {
                    console.log("Error al obtener el ProductoMásVendido: ", error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Ocurrió un error al mostrar el ProductoMásVendido. Por favor, inténtalo de nuevo más tarde.',
                        footer: `Detalles del error: ${error.message}`
                    });
                });
        }
    }
};
</script>

<style scoped>
/* Agrega estilos CSS si es necesario */
</style>