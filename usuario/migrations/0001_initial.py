# Generated by Django 3.2.3 on 2021-07-14 03:02

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    initial = True

    dependencies = [
        ('core', '0001_initial'),
    ]

    operations = [
        migrations.CreateModel(
            name='Usuario',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('password', models.CharField(max_length=128, verbose_name='password')),
                ('last_login', models.DateTimeField(blank=True, null=True, verbose_name='last login')),
                ('username', models.CharField(max_length=100, unique=True, verbose_name='Nombre de usuario')),
                ('correo', models.CharField(max_length=300, unique=True, verbose_name='Correo')),
                ('nombre_completo', models.CharField(max_length=150, verbose_name='Nombre Completo')),
                ('rut', models.IntegerField(unique=True, verbose_name='Run')),
                ('telefono', models.IntegerField(unique=True, verbose_name='Telefono')),
                ('direccion', models.TextField(default='', max_length=300, null=True, verbose_name='Dirección')),
                ('usuario_activo', models.BooleanField(default=True)),
                ('usuario_administrador', models.BooleanField(default=False)),
                ('cargo', models.ForeignKey(default=1, null=True, on_delete=django.db.models.deletion.CASCADE, to='core.cargo')),
            ],
            options={
                'abstract': False,
            },
        ),
    ]
