$("#formCreate").validate({

    rules: {
        txtName: {
            required: true,
            maxlength: 30
        },
        txtColor: {
            required: true,
            maxlength: 20
        },
        txtPlanet: {
            required: true,
            maxlength: 30
        },
        txtMeaning: {
            required: true,
            maxlength: 400
        }
    },
    messages: {
        txtName: {
            required: "Please, type the kyber name",
            maxlength: "The name can't have more than 30 characters"
        },
        txtColor: {
            required: "Please, type the kyber color",
            maxlength: "The color can't have more than 20 characters"
        },
        txtPlanet: {
            required: "Please, type the kyber planet",
            maxlength: "The planet can't have more than 30 characters"
        },
        txtMeaning: {
            required: "Please, type your the kyber meaning",
            maxlength: "The meaning can't have more than 400 characters"
        }
    }
});