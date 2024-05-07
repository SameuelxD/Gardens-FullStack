<template>
    <div class="container">
        <h2 class="item_title">Clientes sin Pagos</h2>
        <table class="table table-dark">
            <thead>
                <tr>
                    <th scope="col">Codigo Cliente</th>
                    <th scope="col">Nombre Cliente</th>
                    <th scope="col">Codigo Empleado</th>
                    <th scope="col">Nombre Empleado</th>
                    <th scope="col">Codigo Oficina</th>
                    <th scope="col">Ciudad</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(cliente, index) in clientesSinPagosList" :key="index">
                    <td>{{ cliente.codigoCliente }}</td>
                    <td>{{ cliente.nombreCliente }}</td>
                    <td>{{ cliente.codigoEmpleadoRepVentas }}</td>
                    <td>{{ cliente.nombreEmpleado }}</td>
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
            clientesSinPagosList: [],
            API_URL: process.env.VUE_APP_API_URL,
            API_IIS: process.env.VUE_APP_API_IIS
        };
    },
    mounted() {
        this.listClientesSinPagos();
    },
    methods: {
        listClientesSinPagos() {
            axios.get(this.API_IIS + '/api/Cliente/ClientesSinPagos', { withCredentials: true })
                .then(response => {
                    this.clientesSinPagosList = response.data;
                })
                .catch(error => {
                    console.log("Error al mostrar la lista de ClientesSinPagos ", error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Ocurrió un error al mostrar la lista de ClientesSinPagos. Por favor, inténtalo de nuevo más tarde.',
                        footer: `Detalles del error: ${error.message}`
                    });
                });
        }
    }
};
</script>

<style scoped></style>