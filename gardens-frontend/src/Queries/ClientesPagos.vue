<template>
    <div class="container">
        <h2 class='item_title'>Informacion Clientes con Pagos</h2>
        <table class="table table-dark">
            <thead>
                <tr>
                    <th scope="col">Código Cliente</th>
                    <th scope="col">Nombre Cliente</th>
                    <th scope="col">Codigo Representante-Ventas</th>
                    <th scope="col">Nombre Representante-Ventas</th>
                    <th scope="col">Codigo Oficina</th>
                    <th scope="col">Ciudad Oficina Representante-Ventas</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(val, key) in clientesPagosList" :key="key">
                    <td>{{ val.codigoCliente }}</td>
                    <td>{{ val.nombreCliente }}</td>
                    <td>{{ val.codigoEmpleadoRepVentas }}</td>
                    <td>{{ val.nombreEmpleado }}</td>
                    <td>{{ val.codigoOficina }}</td>
                    <td>{{ val.ciudad }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import Swal from 'sweetalert2';

export default {
    data() {
        return {
            clientesPagosList: [],
            API_URL: process.env.VUE_APP_API_URL,
            API_IIS: process.env.VUE_APP_API_IIS
        };
    },
    created() {
        this.listClientesPagos();
    },
    methods: {
        listClientesPagos() {
            axios.get(this.API_IIS + '/api/Cliente/ClientesPagos', { withCredentials: true })
                .then(response => {
                    this.clientesPagosList = response.data;
                })
                .catch(error => {
                    console.error('Error al mostrar la lista de ClientesPagos', error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Ocurrió un error al mostrar la lista de ClientesPagos. Por favor, inténtalo de nuevo más tarde.',
                        footer: `Detalles del error: ${error.message}`
                    });
                });
        }
    }
};
</script>

<style scoped></style>