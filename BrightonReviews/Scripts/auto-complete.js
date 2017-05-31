
$(document).ready(function () {


    //AOS.init();

    //Autocomplete JqueryUi
    var submitAutocompleteForm = function (event, ui) {

        var $input = $(this);
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();

    };

    var createAutocomplete = function () {

        var $input = $(this);

        var options = {
            source: $input.attr("data-autocomplete"),
            select: submitAutocompleteForm
        };

        $input.autocomplete(options);
    };

    $("input[data-autocomplete]").each(createAutocomplete);

});