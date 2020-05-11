$(() => {

    let counter = 1;

    $("#add-person").on('click', () => {
        $("#a-person").append(`<div class="col-md-4">
                    <input name="ppl[${counter}].FirstName" type="text" class="form-control" placeholder="First Name" />
                </div>
                <div class="col-md-4">
                    <input name="ppl[${counter}].LastName" type="text" class="form-control" placeholder="Last Name" />
                </div>
                <div class="col-md-4">
                    <input name="ppl[${counter}].Age" type="text" class="form-control" placeholder="Age" />
                </div>
                <br /> <br />`);
        counter++;
    });

});