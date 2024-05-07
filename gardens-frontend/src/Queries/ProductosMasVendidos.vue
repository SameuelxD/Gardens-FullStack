<template>
    <div class="container">
        <h2 class="item_title">Información de los 20 productos más vendidos</h2>
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
                <tr v-for="(item, index) in productosMasVendidosList" :key="index">
                    <td>{{ item.codigoProducto }}</td>
                    <td>{{ item.nombre }}</td>
                    <td>{{ item.gama }}</td>
                    <td>{{ item.dimensiones }}</td>
                    <td>{{ item.proveedor }}</td>
                    <td>{{ item.descripcion }}</td>
                    <td>{{ item.cantidad }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import axios from 'axios';
import Swal from 'sweetalert2';

export default {
    name: 'ProductosMasVendidos',
    data() {
        return {
            productosMasVendidosList: [],
            API_URL: process.env.VUE_APP_API_URL,
            API_IIS: process.env.VUE_APP_API_IIS
        };
    },
    created() {
        this.fetchProductosMasVendidos();
    },
    methods: {
        fetchProductosMasVendidos() {
            axios.get(this.API_IIS + '/api/Producto/ProductosMasVendidos', { withCredentials: true })
                .then(response => {
                    this.productosMasVendidosList = response.data;
                })
                .catch(error => {
                    console.log("Error al mostrar la lista de ProductosMasVendidos: ", error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Ocurrió un error al mostrar la lista de ProductosMasVendidos. Por favor, inténtalo de nuevo más tarde.',
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