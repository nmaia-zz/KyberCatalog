System.register(["jquery"], function (exports_1, context_1) {
    "use strict";
    var $, Teste;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [
            function ($_1) {
                $ = $_1;
            }
        ],
        execute: function () {
            Teste = /** @class */ (function () {
                function Teste() {
                    $(document).ready(function () {
                        alert('pow!');
                    });
                }
                return Teste;
            }());
        }
    };
});
