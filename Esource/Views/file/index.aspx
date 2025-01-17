﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Esource.Views.file.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="file_panel" UpdateMode="Conditional">
        <ContentTemplate>
            <section class="files">
                <div class="row">
                    <div class="col-12 col-md-3 col-lg-2 my-4 my-md-0">
                        <div id="folders-card" class="card">
                            <div class="view view-cascade primary-light-gradient py-2 mx-4 mb-0 d-flex justify-content-center align-items-center text-center">
                                <h4 class="mx-3">Files</h4>
                            </div>

                            <asp:LinkButton runat="server" ID="viewOwn_Btn" CssClass="link black-text" OnClick="viewOwn_Btn_Click">
                                <h6 class="pt-2 pl-3 mb-3">
                                    <i class="fas fa-hdd mr-2"></i>My Drive
                                </h6>
                            </asp:LinkButton>

                            <hr class="my-0">

                            <asp:LinkButton runat="server" ID="viewShared_Btn" CssClass="link black-text" OnClick="viewShared_Btn_Click">
                                <h6 class="pt-2 pl-3 mt-3 mb-3">
                                    <i class="fas fa-users mr-2"></i>Shared With Me
                                </h6>
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div class="col-12 col-md-9 col-lg-7">
                        <div id="files-card" class="card">
                            <div class="card-body p-0">
                                <div class="table-responsive table-hover w-100">
                                    <table id="files-table" class="table table-striped text-center mb-0">
                                        <thead class="deep-purple accent-3 white-text">
                                            <th id="select" class="rounded-top-left">
                                                <div class="form-check">
                                                    <asp:CheckBox runat="server" ID="check_all" AutoPostBack="true" CssClass="form-check-input" type="checkbox" OnCheckedChanged="check_all_CheckedChanged" />
                                                    <label class="form-check-label" for="check-all"></label>
                                                </div>
                                            </th>
                                            <th id="name" class="th-lg">Name</th>
                                            <th id="sizes" class="d-none d-md-table-cell">Size</th>
                                            <th id="type" class="d-none d-md-table-cell">Type</th>
                                            <th id="shared" class="d-none d-md-table-cell">Shared</th>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater runat="server" ID="files" OnItemCommand="files_ItemCommand" OnItemDataBound="files_ItemDataBound">
                                                <ItemTemplate>
                                                    <tr class="animated faster data-rows">
                                                        <asp:HiddenField runat="server" ID="idField" Value='<%#Eval("Id") %>' />
                                                        <td headers="select">
                                                            <div class="form-check">
                                                                <asp:CheckBox runat="server" AutoPostBack="true" ID="checkFile" CommandArgument='<%#Eval("Id") %>'
                                                                    CssClass="form-check-input files-check" OnCheckedChanged="checkFile_CheckedChanged" />
                                                                <label for='ff-<%#Eval("Id") %>' class="form-check-label"></label>
                                                            </div>
                                                        </td>
                                                        <td headers="name" data-name='<%#Eval("fileName") %>' class="name">
                                                            <asp:LinkButton runat="server" CommandName="download" CssClass="d-flex flex-fill justify-content-center"><%#Eval("fileName") %>
                                                            </asp:LinkButton>
                                                        </td>
                                                        <td headers="size" class="d-md-table-cell"><%#Eval("size") %>
                                                        </td>
                                                        <td headers="type" class="d-md-table-cell text-capitalize"><%#Eval("type") %></td>
                                                        <td headers="shared" class="cursor-default d-md-table-cell">
                                                            <asp:Label runat="server" ID="sharedSpan">Only you</asp:Label>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>

                                <p runat="server" visible="false" id="filesErr" class="text-center grey-text small font-weight-bold mt-3">End of contents</p>
                            </div>
                        </div>
                    </div>

                    <div class="d-none d-lg-block col-3 animated fadeIn">
                        <div id="action-card" class="card card-cascade narrower">
                            <div class="view view-cascade primary-light-gradient narrower py-2 mx-4 mb-0 d-flex justify-content-center align-items-center text-center">
                                <h4 class="mx-3">Actions</h4>
                            </div>

                            <div class="card-body card-body-cascade p-0">
                                <div id="action-search" class="px-3 mt-2 mb-3">
                                    <div class="input-group md-form md-outline">
                                        <input id="action-search-input" class="form-control mdb-autocomplete" type="text" name="search">
                                        <label for="action-search-input">Search</label>
                                        <div class="dropdown input-group-append">
                                            <button class="btn btn-primary btn-md dropdown-toggle m-0" data-toggle="dropdown">
                                                <i class="fas fa-filter"></i>
                                            </button>

                                            <div id="action-filters" class="search-filters dropdown-menu dropdown-menu-right px-3">
                                                <h6 class="dropdown-header px-0 pb-3">Search Filters</h6>

                                                <div class="custom-control custom-checkbox">
                                                    <input type="checkbox" class="custom-control-input filter-all" checked>
                                                    <label class="custom-control-label cursor-pointer" for="filter-all">All</label>
                                                </div>

                                                <div class="custom-control custom-checkbox">
                                                    <input type="checkbox" class="custom-control-input filter-name" checked>
                                                    <label class="custom-control-label cursor-pointer" for="filter-name">Name</label>
                                                </div>

                                                <div class="custom-control custom-checkbox">
                                                    <input type="checkbox" class="custom-control-input filter-size" checked>
                                                    <label class="custom-control-label cursor-pointer" for="filter-size">Size</label>
                                                </div>

                                                <div class="custom-control custom-checkbox">
                                                    <input type="checkbox" class="custom-control-input filter-type" checked>
                                                    <label class="custom-control-label cursor-pointer" for="filter-type">Type</label>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="list-group list-group-flush">
                                    <a class="list-group-item list-group-item-action" data-toggle="modal" data-target="#upload-modal">
                                        <i class="fas fa-cloud-upload-alt mr-1"></i>Upload File(s)
                                    </a>
                                    <%--                            <a class="list-group-item list-group-item-action" data-toggle="modal" data-target="#newfile-modal">
                                <i class="fas fa-file-plus mr-1"></i>New File
                            </a>--%>
                                </div>

                                <hr class="my-0">

                                <div class="animated faster select-actions" id="action_panel" runat="server" visible="false">
                                    <p class="mt-3 mb-1">
                                        <small runat="server" id="items_selected" class="px-3 font-weight-bolder grey-text select-count">0 Item Selected</small>
                                    </p>

                                    <div class="list-group list-group-flush">

                                        <div class="single-select animated faster" id="single_action_panel" runat="server" visible="false">
                                            <asp:LinkButton runat="server" OnClick="btn_Download_Click" ID="btn_Download" CssClass="download list-group-item list-group-item-action">
                                        <i class="fas fa-cloud-download-alt mr-1"></i>Download
                                            </asp:LinkButton>
                                            <a class="list-group-item list-group-item-action" data-toggle="modal" data-target="#share-modal">
                                                <i class="fas fa-share-alt mr-1"></i>Share
                                            </a>
                                            <%--                                    <a class="edit list-group-item list-group-item-action d-none">
                                        <i class="fas fa-edit mr-1"></i>Edit
                                    </a>--%>
                                            <a class="list-group-item list-group-item-action" data-toggle="modal" data-target="#rename-modal">
                                                <i class="fas fa-i-cursor mr-1"></i>Rename
                                            </a>
                                        </div>

                                        <%--                                <a class="list-group-item list-group-item-action move-action" data-toggle="modal" data-target="#move-modal">
                                    <i class="fas fa-exchange-alt mr-1"></i>Move
                                </a>
                                <a class="list-group-item list-group-item-action copy-action" data-toggle="modal" data-target="#copy-modal">
                                    <i class="far fa-copy mr-1"></i>Copy
                                </a>--%>
                                        <asp:LinkButton runat="server" ID="btn_Delete" OnClick="btn_Delete_Click" CssClass="list-group-item list-group-item-action delete-action">
                                    <i class="far fa-trash-alt mr-1"></i>Delete
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- Rename Modal -->
    <div id="rename-modal" class="modal fade" tabindex="-1" role="dialog" data-backdrop="false">
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header deep-purple accent-2 white-text">
                    <h4 class="modal-title">
                        <i class="far fa-i-cursor mr-1"></i>RENAME
                    </h4>

                    <button type="button" class="close" data-dismiss="modal">
                        <span class="white-text">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <div class="input-group mb-4 md-form md-outline">
                        <div class="">
                            <input id="rename_input" runat="server" class="form-control" type="text" name="rename" required>
                            <label for="rename_input">New Name</label>

                        </div>

                        <div class="input-group-append">
                            <asp:LinkButton runat="server" ID="btn_Rename" CssClass="btn btn-md btn-primary m-0 px-3 py-2" OnClick="btn_Rename_Click">
                                <i class="fas fa-i-cursor mr-2"></i>Rename
                            </asp:LinkButton>
                        </div>
                    </div>

                    <small class="form-text text-muted">File name should include file extension. And file name only allow alphanumeric, space, underscore and dash.
                    </small>

                    <input type="hidden" name="fid" value="">
                </div>
            </div>
        </div>
    </div>

    <!-- Share Link Modal -->
    <div id="share-modal" class="modal fade" tabindex="-1" role="dialog" data-backdrop="false">
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header deep-purple accent-2 white-text">
                    <h4 class="modal-title">
                        <i class="far fa-share-alt mr-1"></i>SHARE
                    </h4>

                    <button type="button" class="close" data-dismiss="modal">
                        <span class="white-text">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <div class="input-group mb-4 md-form md-outline">
                        <div class="">
                            <input runat="server" id="share_user_input" class="form-control mdb-autocomplete" type="email" name="shareUser" required>
                            <label for="share_user_input">Email</label>

                        </div>

                        <div class="input-group-append">
                            <asp:LinkButton runat="server" ID="btn_Share" OnClick="btn_Share_Click" CssClass="btn btn-md btn-primary m-0 px-3 py-2">
                                <i class="fas fa-share-alt mr-1"></i>Share
                            </asp:LinkButton>
                        </div>
                    </div>

                    <small class="form-text text-muted">Accepts registered user's email format.
                    </small>

                    <input type="hidden" name="fid" value="">

                    <div runat="server" visible="false" class="share-users" id="sharedUsersDiv">
                        <hr>

                        <h6 class="card-title pt-2">
                            <i class="fas fa-users mr-2"></i>Shared With
                        </h6>
                        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="text-right">
                                    <div class="table-fixed table-hover w-100 mb-3">
                                        <table id="share-users-table" class="table table-striped text-center mb-0">
                                            <thead class="deep-purple accent-3 white-text">
                                                <th id="share-select" class="rounded-top-left">
                                                    <div class="form-check">
                                                        <asp:CheckBox runat="server" ID="checkAllShared" AutoPostBack="true" CssClass="form-check-input" type="checkbox" OnCheckedChanged="checkAllShared_CheckedChanged" />
                                                        <label class="form-check-label" for="checkAllShared"></label>
                                                    </div>
                                                </th>
                                                <th id="share-name">Name</th>
                                                <th id="share-email" class="rounded-top-right">Email</th>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater runat="server" ID="sharedUsers">
                                                    <ItemTemplate>
                                                        <tr class="animated faster">
                                                            <td headers="share-select">
                                                                <div class="form-check">
                                                                    <asp:CheckBox runat="server" AutoPostBack="true" ID="checkShared" CommandArgument='<%#Eval("Id") %>'
                                                                        CssClass="form-check-input files-check" OnCheckedChanged="checkShared_CheckedChanged" />
                                                                    <label for='ff-<%#Eval("Id") %>' class="form-check-label"></label>
                                                                </div>
                                                            </td>
                                                            <td headers="share-name" class="d-md-table-cell"><%#Eval("username") %></td>
                                                            <td headers="share-email" class="d-md-table-cell"><%#Eval("email") %></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                    <asp:LinkButton runat="server" CssClass="btn btn-md btn-danger animated faster" ID="unshareBtn" Visible="false" OnClick="unshareBtn_Click">
                                <i class="fas fa-user-times mr-2"></i>Unshare with selected user(s)
                                    </asp:LinkButton>

                                    <input type="hidden" name="fid" value="">
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <%--                <div class="modal-footer d-block">
                    <div class="needs-validation d-block d-md-flex flex-fill">
                        <div class="flex-md-fill mb-3 mt-0 mb-md-auto mt-md-auto text-left">
                            <i class="far fa-unlink fa-sm border border-primary rounded-circle p-2 mr-2"></i>
                            <span class="align-middle">Share link not created</span>
                        </div>

                        <div class="flex-md-fill text-left text-md-right">
                            <button class="btn btn-md btn-primary m-0" type="submit">
                                <i class="fas fa-link mr-2"></i>Create Share Link
                            </button>
                        </div>

                        <input type="hidden" name="fid" value="">
                    </div>
                </div>--%>
            </div>
        </div>
    </div>

    <!-- Upload Files Modal -->
    <div id="upload-modal" class="modal fade" tabindex="-1" role="dialog" data-backdrop="false">
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header deep-purple accent-2 white-text">
                    <h4 class="modal-title">
                        <i class="fas fa-cloud-upload-alt mr-1"></i>UPLOAD FILE(S)
                    </h4>

                    <a class="close" data-dismiss="modal">
                        <span class="white-text">&times;</span>
                    </a>
                </div>

                <div class="modal-body">
                    <div class="filepreview">
                        <div class="wrapper card card-body view overlay text-center z-depth-2" id="file-wrapper">
                            <div class="mask rgba-black-slight"></div>
                            <div class="preview deep-purple accent-3">
                                <img src="<%=Page.ResolveUrl("~/Content/img/placeholder.jpg") %>" id="poster" />
                                <div id="fileMask" class="infos d-none">
                                    <div class="infos-inner">
                                        <i class="fas fa-file fa-5x"></i>
                                        <p id="maskText" class="filename"></p>
                                        <a class="btn btn-sm btn-success">Change file</a>
                                    </div>
                                </div>
                            </div>
                            <div class="card-text">
                                <i class="fas fa-5x fa-cloud-download-alt"></i>
                                <p class="font-weight-bolder">No File Uploaded</p>
                            </div>
                            <div class="custom-file">
                                <asp:FileUpload runat="server" ID="upPoster" AllowMultiple="true" />
                            </div>
                        </div>
                    </div>
                    <div class="text-center">
                        <a id="fileRemove" class="btn btn-danger btn-sm text-center d-none" style="z-index: 3;">Remove file</a>
                    </div>
                    <p class="text-center m-0 mt-3">
                        <small class="form-text text-muted">You are can only upload up to a maximum of 100mb.
                        </small>
                        <small class="form-text text-danger font-weight-500">* If uploaded file or files exist, that file or files will be overwritten.
                        </small>
                    </p>
                    <asp:LinkButton runat="server" ID="uploadBtn" Text="Upload" CssClass="btn btn-block btn-success" OnClick="uploadBtn_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/Scripts/files.js") %>"></script>
</asp:Content>
