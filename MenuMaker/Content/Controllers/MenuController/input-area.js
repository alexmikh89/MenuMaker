function GetDynamicRecipeInputFields(e) {
    var hold = $(e).parents(".week-day");

    var cloneDiv = hold.find(".recipe-input-fields").eq(0).clone();
    hold.find(".recipe-input-fields").eq(-1).after(cloneDiv);
}



function Remove(button) {
    var row = $(button).closest("TR");
    var name = $("TD", row).eq(0).html();
    if (confirm("Do you want to delete: " + name)) {
        //Get the reference of the Table.
        var table = $("#tblCustomers")[0];

        //Delete the Table row using it's Index.
        table.deleteRow(row[0].rowIndex);
    }
}