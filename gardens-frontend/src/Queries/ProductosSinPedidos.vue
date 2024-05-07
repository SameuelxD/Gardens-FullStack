<template>
    <div class="container">
        <h2 class="item_title">Productos sin Pedidos</h2>
        <table class="table table-dark">
            <thead>
                <tr>
                    <th scope="col">Código Producto</th>
                    <th scope="col">Nombre</th>
                    <th scope="col">Descripción</th>
                    <th scope="col">Imagen</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(producto, index) in productosSinPedidosList" :key="index">
                    <td>{{ producto.codigoProducto }}</td>
                    <td>{{ producto.nombreProducto }}</td>
                    <td>{{ producto.descripcion }}</td>
                    <td>{{ producto.imagen }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import axios from 'axios';
import Swal from 'sweetalert2';

export default {
    data() {
        return {
            productosSinPedidosList: [],
            API_URL: process.env.VUE_APP_API_URL,
            API_IIS: process.env.VUE_APP_API_IIS
        };
    },
    created() {
        this.listProductosSinPedidos();
    },
    methods: {
        listProductosSinPedidos() {
            axios.get(this.API_IIS + '/api/Producto/ProductosSinPedidos', { withCredentials: true })
                .then(response => {
                    this.productosSinPedidosList = response.data;

                })
                .catch(error => {
                    console.error('Error al mostrar la lista de ProductosSinPedidos', error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Ocurrió un error al mostrar la lista de ProductosSinPedidos. Por favor, inténtalo de nuevo más tarde.',
                        footer: `Detalles del error: ${error.message}`
                    });
                });
        }
    }
};
</script>

<style scoped>
/* Estilos aquí */
</style>