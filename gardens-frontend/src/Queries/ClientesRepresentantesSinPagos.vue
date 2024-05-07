<template>
    <div class="container">
        <h2 class="item_title">Informacion Clientes sin pagos con sus Representantes de Ventas</h2>
        <table class="table table-dark">
            <thead>
                <tr>
                    <th scope="col">Código Cliente</th>
                    <th scope="col">Nombre Cliente</th>
                    <th scope="col">Codigo Representante-Ventas</th>
                    <th scope="col">Nombre Representante-Ventas</th>
                    <th scope="col">Codigo Oficina</th>
                    <th scope="col">Ciudad Oficina</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(cliente, index) in clientesRepresentanteSinPagosList" :key="index">
                    <td>{{ cliente.codigoCliente }}</td>
                    <td>{{ cliente.nombreCliente }}</td>
                    <td>{{ cliente.codigoEmpleadoRepVentas }}</td>
                    <td>{{ cliente.nombreEmpleado }} </td>
                    <td>{{ cliente.codigoOficina }}</td>
                    <td>{{ cliente.ciudad }}</td>
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
            clientesRepresentanteSinPagosList: [],
            API_URL: process.env.VUE_APP_API_URL,
            API_IIS: process.env.VUE_APP_API_IIS
        };
    },
    mounted() {
        this.listClientesRepresentanteSinPagos();
    },
    methods: {
        listClientesRepresentanteSinPagos() {
            axios.get(this.API_IIS + '/api/Cliente/ClientesSinPagos', { withCredentials: true })
                .then(response => {
                    this.clientesRepresentanteSinPagosList = response.data;
                })
                .catch(error => {
                    console.log("Error al mostrar la lista de ClientesRepresentanteSinPagos ", error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Ocurrió un error al mostrar la lista de ClientesRepresentanteSinPagos. Por favor, inténtalo de nuevo más tarde.',
                        footer: `Detalles del error: ${error.message}`
                    });
                });
        }
    }
};
</script>

<style scoped></style>