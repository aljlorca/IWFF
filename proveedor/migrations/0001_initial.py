# Generated by Django 4.0.3 on 2022-03-19 16:26

from django.db import migrations, models


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='proveedor',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('rut', models.IntegerField()),
                ('nombre', models.TextField()),
                ('telefono', models.IntegerField()),
                ('rubro', models.TextField()),
            ],
        ),
    ]
