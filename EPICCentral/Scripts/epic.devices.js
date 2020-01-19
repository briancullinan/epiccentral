
$(document).ready(function () {

    // Initialize confirmation diaglog.
    $("#confirmRetire").dialog({
        autoOpen: false,
        modal: true
    });

    // Initialize to current state. Save current state whenever DDL is clicked.
    var lastDeviceState = $("#DeviceState option:selected");
    $("#DeviceState").click(
        function () {
            lastDeviceState = $("#DeviceState option:selected");
        }
    );

    // When device state changes to "Retired" ask user to confirm.
    $("#DeviceState").change(
        function (e) {
            e.preventDefault();
            if (this.options[this.selectedIndex].value == 'Retired') {
                // Save locally because it changes before button functions are invoked.
                var deviceState = lastDeviceState;
                $("#confirmRetire").dialog({
                    width: 480,
                    height: 180,
                    resizable: false,
                    buttons: {
                        "Confirm": function () {
                            // Do nothing here; allow option to change.
                            $("#confirmRetire").dialog("close");
                        },
                        "Cancel": function () {
                            // Reset selected back to previous selected state.
                            deviceState.attr("selected", true);
                            $("#confirmRetire").dialog("close");
                        }
                    }
                });

                // Dialog configured. Open it.
                $("#confirmRetire").dialog("open");
            }
        }
    );

    // When organization changes, reload locations.
    $("#OrganizationId").change(
        function () {
            var orgId = this.options[this.selectedIndex].value;
            $("#LocationId").empty();
            if (orgId !== null && orgId.length > 0) {
                $.post( $( this ).data( 'loadUrl' ), { organizationId: orgId },
                    function( data ) {
                        $.each( data, function( index, location ) {
                            $( "#LocationId" ).append( $( '<option>', { value: location.Id } ).text( location.Name ) );
                        } );
                    }
                );
            }
        }
    );
});
