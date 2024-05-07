<template>
    <div class="container">
        <h2 class="item_title">Información de los productos con ventas totales</h2>
        <table class="table table-dark">
            <thead>
                <tr>
                    <th scope="col">Código Producto</th>
                    <th scope="col">Nombre</th>
                    <th scope="col">Unidades Vendidas</th>
                    <th scope="col">Total Facturado sin Impuestos</th>
                    <th scope="col">Total Facturado con Impuestos</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(item, index) in productosFacturandoList" :key="index">
                    <td>{{ item.codigoProducto }}</td>
                    <td>{{ item.nombre }}</td>
                    <td>{{ item.cantidad }}</td>
                    <td>{{ item.totalFacturado }}</td>
                    <td>{{ item.totalFacturadoIVA }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import axios from 'axios';
import Swal from 'sweetalert2';

export default {
    name: 'ProductosFacturando',
    data() {
        return {
            productosFacturandoList: [],
            API_URL: process.env.VUE_APP_API_URL,
            API_IIS: process.env.VUE_APP_API_IIS
        };
    },
    created() {
        this.fetchProductosFacturando();
    },
    methods: {
        fetchProductosFacturando() {
            axios.get(this.API_IIS + '/api/Producto/ProductosVentasTotales', { withCredentials: true })
                .then(response => {
                    this.productosFacturandoList = response.data;
                })
                .catch(error => {
                    console.log("Error al mostrar la lista de ProductosFacturando: ", error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Ocurrió un error al mostrar la lista de ProductosFacturando. Por favor, inténtalo de nuevo más tarde.',
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