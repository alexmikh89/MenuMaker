function GetDynamicRecipeInputFields(e) {
    var hold = $(e).parents(".week-day");

    var cloneDiv = hold.find(".recipe-input-fields").eq(0).clone();
    hold.find(".recipe-input-fields").eq(-1).after(cloneDiv);
}