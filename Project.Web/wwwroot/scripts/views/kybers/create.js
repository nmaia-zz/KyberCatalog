$(document).ready(function () {

    $('#btnCreate').click(function () {

        var model = {

            Name: $('#txtName').val(),
            Color: $('#txtColor').val(),
            Planet: $('#txtPlanet').val(),
            Meaning: $('#txtMeaning').val()
        };

        if (isModelOk(model)) {
            $.ajax({

                url: '/Kybers/CreateKyber',
                type: 'POST',
                data: model,
                success: function (data, status, xhr) {

                    if (data.status === 200) {
                        $('#msg').html(data.message);
                        $('.form-control').val('');
                    }
                    else {
                        $('#msg').html(data.message);
                    }
                },
                error: function (e) {

                    $('#msg').html('Error: ' + e.status);
                }
            });
        }
        else
            return;

        function isModelOk(model) {

            var modelOk = [0, 0, 0, 0];
            var modelOnValidation = [];

            Object.keys(model).forEach(function (key) {

                switch (key) {

                    case 'Name':
                        if (!isNameOk(model[key]))
                            modelOnValidation.push(1);
                        else
                            modelOnValidation.push(0);
                        break;
                    case 'Color':
                        if (!isColorOk(model[key]))
                            modelOnValidation.push(1);
                        else
                            modelOnValidation.push(0);
                        break;
                    case 'Planet':
                        if (!isPlanetOk(model[key]))
                            modelOnValidation.push(1);
                        else
                            modelOnValidation.push(0);
                        break;
                    case 'Meaning':
                        if (!isMeaningOk(model[key]))
                            modelOnValidation.push(1);
                        else
                            modelOnValidation.push(0);
                        break;
                    default:
                        break;
                }
            });

            if (areEqual(modelOk, modelOnValidation))
                return true;
            else
                return false;
        }

        function isNameOk(name) {

            if (name === '') {
                $('#chkName').text('Name is required.');
                return false;
            }

            else if (name.length > 30) {
                $('#chkName').text('Name must have less than 30 characters');
                return false;
            }

            else {
                $('#chkName').text('');
                return true;
            }
        }

        function isColorOk(color) {

            if (color === '') {
                $('#chkColor').text('Color is required.');
                return false;
            }

            else if (color.length > 20) {
                $('#chkColor').text('Color must have less than 20 characters');
                return false;
            }

            else {
                $('#chkColor').text('');
                return true;
            }
        }

        function isPlanetOk(planet) {

            if (planet === '') {
                $('#chkPlanet').text('Planet is required.');
                return false;
            }

            else if (planet.length > 30) {
                $('#chkPlanet').text('Planet must have less than 30 characters');
                return false;
            }

            else {
                $('#chkPlanet').text('');
                return true;
            }
        }

        function isMeaningOk(meaning) {

            if (meaning === '') {
                $('#chkMeaning').text('Meaning is required.');
                return false;
            }

            else if (meaning.length > 400) {
                $('#chkMeaning').text('Meaning must have less than 400 characters');
                return false;
            }

            else {
                $('#chkMeaning').text('');
                return true;
            }
        }

        function areEqual(arr1, arr2) {
            if (arr1.length !== arr2.length)
                return false;
            for (var i = arr1.length; i--;) {
                if (arr1[i] !== arr2[i])
                    return false;
            }

            return true;
        }
    });
});