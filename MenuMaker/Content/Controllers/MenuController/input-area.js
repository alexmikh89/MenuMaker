﻿function GetDynamicRecipeInputFields(e) {
    var hold = $(e).parents(".week-day");

    var cloneDiv = hold.find(".hidden .recipe-input-fields").eq(0).clone();

    hold.find(".recipe-input-fields").eq(-1).after(cloneDiv);
}

function Remove(e) {
    $(e).parents(".form-group").remove();
}