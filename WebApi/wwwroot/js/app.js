var app = new Vue({
    el: '#app',
    data() {
        return {
            message: 'Hello Vue!',
            clinicId: 0,
            clinics: [],
            patients: [],
            sortingPriority: [],
            backendSortingEnabled: true,
            order:'none'
        }
    },
    watch: {
        clinicId() {
            this.order = 'none'
            this.getPatients()
        }
    },
    created() {
        axios
            .get('/Clinics/clinics')
            .then(response => (this.clinics = response.data))
    },
    mounted() {
        console.log(`the component is now mounted.`)
    },
    methods: {
        isCurrent(id){
          return this.clinicId === id;  
        },
        setClinicId(clinicId) {
            this.clinicId = clinicId;
        },
        getPatients() {
            axios
                .get(`/Clinics/Patients?clinicId=${this.clinicId}&order=${this.order}`)
                .then(response => (this.patients = response.data))
        },
        sortPressed(field, order) {
            this.order = order
            this.getPatients()
        },
    }
})