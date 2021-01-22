<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="reset.aspx.cs" Inherits="Esource.Views.auth.reset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="login">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body text-center">
                        <h3 class="text-center">Change Password</h3>

                        <div class="md-form md-outline">
                            <input runat="server" id="password" type="password" name="newpass" class="form-control" />
                            <label for="password">New Password</label>
                        </div>
                        <div class="md-form md-outline">
                            <input runat="server" id="confirmpass" type="password" name="newconfirmpass" class="form-control" />
                            <label for="confirmpass">Confirm Password</label>
                        </div>

                        <asp:LinkButton runat="server" ID="btnReset" CssClass="btn btn-primary" OnClick="btnReset_Click">Reset Password</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
