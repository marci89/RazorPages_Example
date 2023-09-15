
$(document).ready(function () {

    // Function to handle delete confirmation by button click
    $(".delete-user-btn").click(function (e) {
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
                    url: "/User/Delete",
                    method: "POST",
                    data: { id: itemId },
                    success: function () {
                        // Handle success, e.g., remove the item from the UI
                        Swal.fire(deleteConfirmationSuccessMessage, "success");
          
                    },
                    error: function () {
                        // Handle error, e.g., show an error message
                        Swal.fire("Error!", deleteConfirmationErrorMessage, "error");
                    },
                });
            }
        });
    });
});