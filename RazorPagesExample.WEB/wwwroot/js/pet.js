

//Create pet
function createPet() {
    // Call the action which return a partial view for modal.
    jQuery.ajax({
        url: "/Pet/CreatePet",
        dataType: "HTML",
        method: "GET",
        success: function (view) {
            ShowModal(view);
        }
    })
};

//Edit pet
function editPet(id) {
    // Call the action which return a partial view for modal.
    jQuery.ajax({
        url: "/Pet/EditPet",
        data: { id: id },
        dataType: "HTML",
        method: "GET",
        success: function (view) {
            ShowModal(view);
        }
    })
};



$(document).ready(function () {

    // Function to handle delete confirmation by button click
    $(".delete-pet-btn").click(function (e) {
        e.preventDefault();
        const itemId = $(this).data("id");

        //Get translate text with jquery from hidden inputs
        const deleteConfirmationTitle = $("#deleteConfirmationTitle").data("localized-text");
        const deleteConfirmationText = $("#deleteConfirmationText").data("localized-text");
        const deleteConfirmationSuccessMessage = $("#deleteConfirmationSuccessMessage").data("localized-text");
        const deleteConfirmationErrorMessage = $("#deleteConfirmationErrorMessage").data("localized-text");
        const confirmButtonText = $("#confirmButtonText").data("localized-text");
        const cancelButtonText = $("#cancelButtonText").data("localized-text");

        Swal.fire({
            title: deleteConfirmationTitle,
            text: deleteConfirmationText,
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#d33",
            cancelButtonColor: "#3085d6",
            cancelButtonText: cancelButtonText,
            confirmButtonText: confirmButtonText,

        }).then((result) => {
            if (result.isConfirmed) {
                // Perform the delete action, e.g., by making an AJAX request
                $.ajax({
                    url: "/Pet/Delete",
                    method: "POST",
                    data: { id: itemId },
                    success: function () {

                        // Remove the row from the table
                        const deletedRowId = itemId;
                        $(`tr[data-id="${deletedRowId}"]`).remove();

                        Swal.fire(deleteConfirmationSuccessMessage, "success");

                    },
                    error: function () {

                        Swal.fire("Error!", deleteConfirmationErrorMessage, "error");
                    },
                });
            }
        });
    });
});