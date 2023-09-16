//#region Modal


/**
* Show modal
* @param view {string} - This is the returned html (view) from action.
*/
function ShowModal(view) {

    updateModalContent(view);

    // Trigger the modal by setting the data-bs-toggle attribute
    jQuery("#Modal").attr("data-bs-toggle", "modal");
}

/**
 * Adding the view to modal.
 * @param content {string} - This is the returned html (view).
 */
function updateModalContent(content) {
    jQuery("#ModalContent").html(content);
}

/**
* Modal close
* */
function closeModal() {
    debugger;
    jQuery("#Modal").modal("hide");
}

//#endregion Modal