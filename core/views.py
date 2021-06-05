from django.contrib.messages.api import success
from django.core import paginator
from django.http import request
from django.http.response import Http404
from django.shortcuts import render, redirect, get_object_or_404
from .models import  *
from .forms import *
from django.contrib import messages
from django.core.paginator import Paginator
from django.contrib.auth import authenticate,login
# Create your views here.

def home(request):
    productos = producto.objects.all()
    data = {
        'producto': productos
    }
    return render(request, 'core/home2.html', data)

def contacto(request):
    data = {
        'form': ContactoForms()
    }
    if request.method == 'POST':
        formulario = ContactoForms(data=request.POST)
        if formulario.is_valid():
            formulario.save()
            data["mensaje"] = "contacto guardado"
        else:
            data["form"] = formulario
    return render(request, 'core/Contacto.html',data)

def agregar_producto(request):

    data = {
        'form': AgregarProductoForms()  
    }
    if request.method == 'POST':
        formulario = AgregarProductoForms(data=request.POST, files=request.FILES)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Producto registrado correctamente ")
        else:
            data["form"] = formulario
            messages.warning(request, "ERROR: El producto no fue registrado")

    return render(request, 'core/producto/agregar.html', data)

def listar_productos(request):
    productos = producto.objects.all()
    page = request.GET.get('page', 1)

    try:  
        #cambiar ultimo digito por cantidad de productos que se muestren en el listado
        paginator = Paginator(productos , 10)
        productos = paginator.page(page)
    except:
        raise Http404


    data = {
        'producto': productos,
        'paginator': paginator
    }
    return render(request, 'core/producto/listar.html',data)

def modificar_producto(request, id):

    product = get_object_or_404(producto, id=id)
    data = {
        'form': AgregarProductoForms(instance=product)
    }
    if request.method == 'POST':
        formulario = AgregarProductoForms(data=request.POST,instance=product, files=request.FILES)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Producto modificado correctamente ")
            return redirect(to="listar_producto")
        else:
            data["form"] = formulario
            
    return render(request, 'core/producto/modificar.html', data)

def eliminar_producto(request, id ):
    prod = get_object_or_404(producto, id=id)
    prod.delete()
    messages,success(request, "Producto eliminado correctamente")
    return redirect(to="listar_producto")


def register(request):
    data = {
        'form':RegistroForms()
    }
    if request.method == 'POST':
        formulario = RegistroForms(data=request.POST)
        if formulario.is_valid():
            formulario.save()
            user = authenticate(username=formulario.cleaned_data["username"],password=formulario.cleaned_data["password1"])
            login(request, user)
            messages.success(request, "Registro exitoso")
            return redirect(to="home")
        data['from'] = formulario
    return render(request, 'registration/register.html', data)

