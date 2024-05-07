<template>
    <div class="container">
        <h2 class="item_title">Empleados con sus Jefes y su Jefe Superior</h2>
        <table class="table table-dark">
            <thead>
                <tr>
                    <th scope="col">Código Empleado</th>
                    <th scope="col">Nombre Empleado </th>
                    <th scope="col">Código Jefe</th>
                    <th scope="col">Nombre Jefe</th>
                    <th scope="col">Código Jefe-Superior</th>
                    <th scope="col">Nombre Jefe-Superior</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(employee, index) in empleadosJefesList" :key="index">
                    <td>{{ employee.codigoEmpleado }}</td>
                    <td>{{ employee.nombreEmpleado }}</td>
                    <td>{{ employee.codigoJefe1 }}</td>
                    <td>{{ employee.nombreJefe1 }}</td>
                    <td>{{ employee.codigoJefe2 }}</td>
                    <td>{{ employee.nombreJefe2 }}</td>
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
            empleadosJefesList: [],
            API_URL: process.env.VUE_APP_API_URL,
            API_IIS: process.env.VUE_APP_API_IIS
        };
    },
    created() {
        this.listEmpleadosJefes();
    },
    methods: {
        listEmpleadosJefes() {
            axios.get(this.API_IIS + '/api/Empleado/EmpleadosJefesyJefes', { withCredentials: true })
                .then(response => {
                    this.empleadosJefesList = response.data;
                })
                .catch(error => {
                    console.error('Error al mostrar la lista de EmpleadosJefes', error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Ocurrió un error al mostrar la lista de EmpleadosJefes. Por favor, inténtalo de nuevo más tarde.',
                        footer: `Detalles del error: ${error.message}`
                    });
                });
        }
    }
};
</script>

<style scoped></style>